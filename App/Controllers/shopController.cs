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
using System.Web;
using System.IO;

namespace App.Controllers
{
    /// <summary>
    /// shop
    /// </summary>
    public class shopController : BaseController
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
        public ActionResult Details(int id)
        {
            shop item = m_BLL.GetById(id);
            return View(item);

        }

        
        public ActionResult Welcome(int id)
        {
            shop item = m_BLL.GetById(id);
            return View(item);

        }

        public ActionResult Info(int id)
        {
            shop item = m_BLL.GetById(id);
            return View(item);

        }

        public ActionResult activity(int id)
        {
            shop item = m_BLL.GetById(id);
            return View(item);

        }

        public ActionResult room_price(int id)
        {
            shop item = m_BLL.GetById(id);
            return View(item);
        }

        public ActionResult youhui(int id)
        {
            shop item = m_BLL.GetById(id);
            return View(item);

        }

        public ActionResult food_list(int id)
        {
            shop item = m_BLL.GetById(id);
            return View(item);

        }

        public JsonResult ApiDetails(int id)
        {
            shop item = m_BLL.GetById(id);
            return Json(item,JsonRequestBehavior.AllowGet);

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
        public ActionResult Create(shop entity)
        {           
            if (entity != null && ModelState.IsValid)
            {
                //string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;
              
                   
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.InsertSucceed  + "，shop的信息的Id为" + entity.id,"shop",
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
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.InsertFail + "，shop的信息，" + returnValue,"shop", 
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
            shop item = m_BLL.GetById(id);
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
        public ActionResult Edit(int id, shop entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验
            
                string currentPerson = GetCurrentPerson();                 
              //entity.UpdateTime = DateTime.Now;
              //entity.UpdatePerson = currentPerson;
                           
                string returnValue = string.Empty;   
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，shop信息的Id为" + id,"shop",
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
                    LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，shop信息的Id为" + id + "," + returnValue, "shop", 
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

        IBLL.IshopBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public shopController()
            : this(new shopBLL()) { }

        public shopController(shopBLL bll)
        {
            m_BLL = bll;
        }


        public ContentResult Upload(HttpPostedFileBase fileData)
        {
            //HttpContext.Request.ContentType = "text/plain";
            //HttpContext.Request.ContentEncoding = System.Text.Encoding.g;
            //string s = EnCodeCovert("utf-8","utf-8", fileData.FileName);

            //int uuserid = 0;
            //string uusername = string.Empty;
            //if (!string.IsNullOrEmpty(userid))
            //{
            //    string[] userarray = userid.Split('!');
            //    uuserid = int.Parse(userarray[0]);
            //    uusername = userarray[1];
            //}
            //string result = "0";
            if (fileData != null)
            {
                try
                {
                    //int UserID = GetCurrentPerson().UserID;
                    //string UserName = GetCurrentPerson().UserName;
                    int Length = fileData.ContentLength;

                    string newFileName = fileData.FileName.Replace(" ", string.Empty);


                    string fileExt = Path.GetExtension(newFileName);
                    if (newFileName.Length > 50)
                    {
                        newFileName = newFileName.Substring(0, 45) + fileExt;
                    }

                    //判断同文件名和大小的文件是否在数据库存在
                    //bool fileisexist = _IDocumentService.fileisexist(newFileName, fileExt.Trim('.'), Length);
                    //if (fileisexist)
                    //{
                    //    return Content("isexist");
                    //}


                    //获取文件流的前500个byte 的md5
                    Stream get_file = fileData.InputStream;
                    byte[] data = new byte[8000];
                    get_file.Read(data, 0, data.Length);
                    //System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    //byte[] hash_byte = get_md5.ComputeHash(data);
                    //string resule = System.BitConverter.ToString(hash_byte);
                    //resule = resule.Replace("-", "");
                    //bool fileisexist = _IDocumentService.pdfileisexist(resule);
                    //if (fileisexist)
                    //{
                    //    return Content("isexist");
                    //}


                    string fileName = newFileName.Replace(fileExt, "") + "&" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + fileExt;

                    string dir = System.Configuration.ConfigurationManager.AppSettings["DocUploadFolder"];
                    string newpath = System.Configuration.ConfigurationManager.AppSettings["DocUploadFolder"] +"\\";

                    //string dir = Request.MapPath("~" + folder + "/");
                    if (!Directory.Exists(newpath))
                        Directory.CreateDirectory(newpath);
                    fileData.SaveAs(Path.Combine(newpath + "\\" + fileName));

                    //result = fileName;


                    //把文件上传到服务器
                    //添加一条文档表，并且把文档id传回去，放到hidden中。

                   

                }
                catch
                {

                }
            }
            return Content("1");
        }
        
    }
}

