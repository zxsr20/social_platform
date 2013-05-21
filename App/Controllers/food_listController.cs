using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using DAL;
using BLL;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using App.Models;

namespace App.Controllers
{
    /// <summary>
    /// food_list
    /// </summary>
    public class food_listController : BaseController
    {
        /// <summary>
        /// Flexigrid异步加载数据
        /// </summary>
        /// <param name="param">Flexigrid传过到后台的参数</param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public JsonResult FlexigridList(string id, FlexigridParam param)
        {
            addUserFilter(param);


            return Json(m_BLL.FlexigridList(id, param));
        }

        
        /// <summary>
        ///  导出Excle
        /// </summary>
        /// <param name="param">Flexigrid传过到后台的参数</param>
        /// <returns></returns>     
        [HttpPost]
        public ActionResult GetDaoChu(string id, FlexigridParam param)
        {
            addUserFilter(param);
            var query = m_BLL.DaoChu(id,param).ToArray();
            var fileName = WriteExcle(param, query, 1);
            return Content(fileName);
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
        
            return View();
        }
        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]  
        public ActionResult Details(int id)
        {
            food_list item = m_BLL.GetById(id);
            return View(item);

        }
 
        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(int? id)
        { 
            
            return View();
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public ActionResult Create(food_list entity)
        {           
            if (entity != null && ModelState.IsValid)
            {
                //string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;
                entity.userid = GetCurrentPerson();
                entity.filltime = DateTime.Now;
                   
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.InsertSucceed  + "，food_list的信息的Id为" + entity.id,"food_list",
                        Result.Succeed);//写入日志 
                    return Json(Suggestion.InsertSucceed);
                }
                else
                { 
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.InsertFail + "，food_list的信息，" + returnValue,"food_list", 
                        Result.Fail);//写入日志                      
                    return Json(Suggestion.InsertFail  + returnValue); //提示插入失败
                }
            }

            return Json(Suggestion.InsertFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对 
        }
        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(int id)
        {
            food_list item = m_BLL.GetById(id);
            return View(item);
        }
        /// <summary>
        /// 提交编辑信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="collection">客户端传回的集合</param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public ActionResult Edit(int id, food_list entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验
            
                //string currentPerson = GetCurrentPerson();                 
              //entity.UpdateTime = DateTime.Now;
              //entity.UpdatePerson = currentPerson;
                           
                string returnValue = string.Empty;   
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，food_list信息的Id为" + id,"food_list",
                        Result.Succeed);//写入日志                           
                    return Json(Suggestion.UpdateSucceed); //提示更新成功 
                }
                else
                { 
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，food_list信息的Id为" + id + "," + returnValue, "food_list", 
                        Result.Fail);//写入日志                           
                    return Json(Suggestion.UpdateFail  + returnValue); //提示更新失败
                }
            }
            return Json(Suggestion.UpdateFail + "请核对输入的数据的格式"); //提示输入的数据的格式不对               
          
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>   
        [HttpPost]
        [SupportFilter]
        public ActionResult Delete(FormCollection collection)
        {
            string returnValue = string.Empty;
            int[] deleteId = collection["query"].GetString().Split(',').Select(s => Convert.ToInt32(s)).ToArray();
            if (deleteId != null && deleteId.Length > 0)
            { 
                if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息",
                        Result.Succeed);//删除成功，写入日志
                    return Json("OK");
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId)+ "," + returnValue, "消息",
                        Result.Fail);//删除失败，写入日志
                }
            }
            return Json(returnValue);
        }
        /// <summary>
        /// 在查询中输入字符串，自动提示的功能
        /// </summary>
        /// <param name="id">需要查询的数据库字段的名称</param>
        /// <param name="term">输入的字符串</param>
        /// <returns></returns>
        public ActionResult SearchAutoComplete(string id, string term)
        { 
            return new ContentResult() { Content = m_BLL.SearchAutoComplete(id, term) };
        }

        IBLL.Ifood_listBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public food_listController()
            : this(new food_listBLL()) { }

        public food_listController(food_listBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}

