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
    /// 角色
    /// </summary>
    public class SysRoleController : BaseController
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
            SysRole item = m_BLL.GetById(id);
            return View(item);

        }
 
        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        { 
                     
            if (null != id)
            {
                using (SysMenuBLL bll = new SysMenuBLL())
                {
                    SysMenu entityId = bll.GetById(id);
                    if (entityId != null)
                    { 
                        SysRole entity = new SysRole();  
                        entity.SysMenuId = id + '&' + entityId.Name;
                        return View(entity);
                    }
                }
            }

            return View();
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public ActionResult Create(SysRole entity)
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
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.InsertSucceed  + "，角色的信息的Id为" + entity.Id,"角色",
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
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.InsertFail + "，角色的信息，" + returnValue,"角色", 
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
            SysRole item = m_BLL.GetById(id);
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
        public ActionResult Edit(string id, SysRole entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验
            
                //string currentPerson = GetCurrentPerson();                 
              //entity.UpdateTime = DateTime.Now;
              //entity.UpdatePerson = currentPerson;
                           
                string returnValue = string.Empty;   
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，角色信息的Id为" + id,"角色",
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
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，角色信息的Id为" + id + "," + returnValue, "角色", 
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

        IBLL.ISysRoleBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public SysRoleController()
            : this(new SysRoleBLL()) { }

        public SysRoleController(SysRoleBLL bll)
        {
            m_BLL = bll;
        }
        
        /// <summary>
        /// 首次设置模块
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult SetSysMenu(string id)
        {
            var entity = m_BLL.GetById(id);
            ViewData["myname"] = entity.Name;
            return View(entity);
        }
        [HttpPost]
        [SupportFilter]
        public ActionResult GetManyData(string id)
        {
            ActionResult r = Json("");

            var entity = m_BLL.GetById(id);
            if (entity != null)
            {
                List<string> list = (from m in entity.SysMenu select m.Id).ToList();
                string ids = "";
                foreach (string l in list)
                {
                    if (ids != "") ids += ",";
                    ids += l;
                }
                r = Json(ids);
            }

            return r;
        }
		/// <summary>
        /// 设置模块
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public ActionResult SetSysMenu(SysRole entity)
        {
            if (entity != null)
            {
                string currentPerson = GetCurrentPerson();
                //entity.UpdateTime = DateTime.Now;
                //entity.UpdatePerson = currentPerson;
                string returnValue = string.Empty;
                if (m_BLL.SetSysMenu(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，角色信息的Id为" + entity.Id, "消息",
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
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", entity.Id)+ "," + returnValue, "消息",
                    Result.Fail);//删除失败，写入日志
                }
            }
            else
            {
                return Json(Suggestion.UpdateFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对               
            }
            return RedirectToAction("Index", "NotFound");
        }

    }
}

