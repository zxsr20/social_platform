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
    /// 模块
    /// </summary>
    public class SysMenuController : BaseController
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
        public ActionResult Details(string id)
        {
            SysMenu item = m_BLL.GetById(id);
            return View(item);

        }
 
        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
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
        public ActionResult Create(SysMenu entity)
        {           
            if (entity != null && ModelState.IsValid)
            {
                //string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;
              
                entity.Id = Result.GetNewId();   
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.InsertSucceed  + "，模块的信息的Id为" + entity.Id,"模块",
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
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.InsertFail + "，模块的信息，" + returnValue,"模块", 
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
        public ActionResult Edit(string id)
        {
            SysMenu item = m_BLL.GetById(id);
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
        public ActionResult Edit(string id, SysMenu entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验
            
                //string currentPerson = GetCurrentPerson();                 
              //entity.UpdateTime = DateTime.Now;
              //entity.UpdatePerson = currentPerson;
                           
                string returnValue = string.Empty;   
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，模块信息的Id为" + id,"模块",
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
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，模块信息的Id为" + id + "," + returnValue, "模块", 
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
            string[] deleteId = collection["query"].GetString().Split(',');
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

        IBLL.ISysMenuBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public SysMenuController()
            : this(new SysMenuBLL()) { }

        public SysMenuController(SysMenuBLL bll)
        {
            m_BLL = bll;
        }
        
        /// <summary>
        /// 获取树形列表的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllMetadata(string id)
        {
            SysMenuBLL m_BLL = new SysMenuBLL();
            List<SysMenuSef> collection = m_BLL.GetAllMetadata(id);
            if (collection != null && collection.Count > 0)
            {
                Metadata metadata = new Metadata();
                metadata.rows = collection;
                return Json(metadata);
            }
            return Json("");
        }

    }
}

