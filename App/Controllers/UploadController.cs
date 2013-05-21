using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;
using BLL;
using Common;
using DAL;

namespace App.Controllers
{
    public class UploadController : BaseController
    {

        IBLL.IshopBLL m_shopBLL;
        IBLL.IactivityBLL m_activityBLL;
        IBLL.Ifood_listBLL m_food_listBLL;
        IBLL.Iroom_priceBLL m_room_priceBLL;
        IBLL.IyouhuiBLL m_youhuiBLL;
        ValidationErrors validationErrors = new ValidationErrors();
        

        public UploadController()
            : this(new shopBLL(), new activityBLL(), new food_listBLL(), new room_priceBLL(), new youhuiBLL()) { }

        public UploadController(shopBLL shopbll,activityBLL activitybll,food_listBLL food_listbll,room_priceBLL room_pricebll,youhuiBLL youhuibll)
        {
            m_shopBLL = shopbll;
            m_activityBLL = activitybll;
            m_food_listBLL = food_listbll;
            m_room_priceBLL = room_pricebll;
            m_youhuiBLL = youhuibll;

        }
        //
        // GET: /Upload/

        public ActionResult Index(int type=0,int bid=0)
        {
            //读取该类型下的图片，然后展示出来，同时也显示上传按钮，上传完成后还可以再上传。
            //当然已上传的图片也可以删除。
            string imgsUrl = string.Empty;
            //if(type==0)
            //{
            //    shop item = m_shopBLL.GetById(bid);
            //    imgsUrl = item.home_pic;
            //}
            //if (type == 1)
            //{
            //    activity item = m_activityBLL.GetById(bid);
            //    imgsUrl = item.pic;
            //}
            shop item;
            activity activity;
            food_list food_list;
            youhui youhui;
            room_price room_price;
            switch (type)
            {
                case 0:
                     item = m_shopBLL.GetById(bid);
                    imgsUrl = item.welcome_pic;
                    break;
                case 1:
                     item = m_shopBLL.GetById(bid);
                    imgsUrl = item.home_pic;
                    break;
                case 2:
                    activity = m_activityBLL.GetById(bid);
                    imgsUrl = activity.pic;
                    break;
                case 3:
                    food_list = m_food_listBLL.GetById(bid);
                    imgsUrl = food_list.pic;
                    break;
                case 4:
                    youhui = m_youhuiBLL.GetById(bid);
                    imgsUrl = youhui.pic;
                    break;
                case 5:
                    room_price = m_room_priceBLL.GetById(bid);
                    imgsUrl = room_price.pic;
                    break;
                default:
                    break;
            }


            
            ViewBag.imgsUrl = imgsUrl;
            ViewBag.type = type;
            ViewBag.bid = bid;
            ViewBag.userid = GetCurrentPerson();

            return View();
        }


        #region 上传文件
        public ContentResult Upload(HttpPostedFileBase fileData, string folder, string userid)
        {
            //HttpContext.Request.ContentType = "text/plain";
            //HttpContext.Request.ContentEncoding = System.Text.Encoding.g;
            //string s = EnCodeCovert("utf-8","utf-8", fileData.FileName);

            int type = 0;
            int  bid = 0;
            string username = "";
            if (!string.IsNullOrEmpty(userid))
            {
                string[] userarray = userid.Split('!');
                type = int.Parse(userarray[0]);
                bid = int.Parse(userarray[1]);
                username = userarray[2];
            }
            string result = "0";
            string fileName = "";
            
            
            

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
                    //Stream get_file = fileData.InputStream;
                    //byte[] data = new byte[8000];
                    //get_file.Read(data, 0, data.Length);
                    //System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    //byte[] hash_byte = get_md5.ComputeHash(data);
                    //string resule = System.BitConverter.ToString(hash_byte);
                    //resule = resule.Replace("-", "");
                    //bool fileisexist = _IDocumentService.pdfileisexist(resule);
                    //if (fileisexist)
                    //{
                    //    return Content("isexist");
                    //}


                     fileName = newFileName.Replace(fileExt, "") + "-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + fileExt;

                    string dir = System.Configuration.ConfigurationManager.AppSettings["DocUploadFolder"];

                    
                    string ss = "/UploadFiles/" + username + "/";
                    string newpath = Server.MapPath(ss);

                    //string dir = Request.MapPath("~" + folder + "/");
                    if (!Directory.Exists(newpath))
                        Directory.CreateDirectory(newpath);
                    fileData.SaveAs(Path.Combine(newpath + "\\" + fileName));

                    //result = fileName;


                   
                    //如果是商店，则更新里面的图片字段，加上上传的图片地址
                    //if (type == 0)
                    //{
                    //    shop item = m_shopBLL.GetById(bid);
                    //    string imgsUrl = item.home_pic;
                    //    imgsUrl = imgsUrl + fileName+";";
                    //    item.home_pic = imgsUrl;
                        
                        
                    //    if (m_shopBLL.SaveChange())
                    //    {
                    //        LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，shop信息的Id为" + bid, "shop",
                    //            Result.Succeed);//写入日志                           
                    //        //return Json(Suggestion.UpdateSucceed); //提示更新成功 
                    //    }
                    //    else
                    //    {
                    //        string returnValue = string.Empty;  
                    //        if (validationErrors != null && validationErrors.Count > 0)
                    //        {
                    //            validationErrors.All(a =>
                    //            {
                    //                returnValue += a.ErrorMessage;
                    //                return true;
                    //            });
                    //        }
                    //        LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，shop信息的Id为" + bid + "," + returnValue, "shop",
                    //            Result.Fail);//写入日志                           
                    //        //return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                    //    }
                    //}


                    shop item;
                    activity activity;
                    food_list food_list;
                    youhui youhui;
                    room_price room_price;
                    string imgsUrl = "";
                    switch (type)
                    {
                        case 0:
                            item = m_shopBLL.GetById(bid);
                        imgsUrl = item.welcome_pic;
                        imgsUrl = imgsUrl + fileName+";";
                        item.welcome_pic = imgsUrl;
                        
                        
                        if (m_shopBLL.SaveChange())
                        {
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，shop信息的Id为" + bid, "shop",
                                Result.Succeed);//写入日志                           
                            //return Json(Suggestion.UpdateSucceed); //提示更新成功 
                        }
                        else
                        {
                            string returnValue = string.Empty;  
                            if (validationErrors != null && validationErrors.Count > 0)
                            {
                                validationErrors.All(a =>
                                {
                                    returnValue += a.ErrorMessage;
                                    return true;
                                });
                            }
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，shop信息的Id为" + bid + "," + returnValue, "shop",
                                Result.Fail);//写入日志                           
                            //return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                        }
                            break;
                        case 1:
                            item = m_shopBLL.GetById(bid);
                         imgsUrl = item.home_pic;
                        imgsUrl = imgsUrl + fileName+";";
                        item.home_pic = imgsUrl;
                        
                        
                        if (m_shopBLL.SaveChange())
                        {
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，shop信息的Id为" + bid, "shop",
                                Result.Succeed);//写入日志                           
                            //return Json(Suggestion.UpdateSucceed); //提示更新成功 
                        }
                        else
                        {
                            string returnValue = string.Empty;  
                            if (validationErrors != null && validationErrors.Count > 0)
                            {
                                validationErrors.All(a =>
                                {
                                    returnValue += a.ErrorMessage;
                                    return true;
                                });
                            }
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，shop信息的Id为" + bid + "," + returnValue, "shop",
                                Result.Fail);//写入日志                           
                            //return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                        }
                            break;
                        case 2:
                            activity = m_activityBLL.GetById(bid);
                            imgsUrl = activity.pic;
                        imgsUrl = imgsUrl + fileName+";";
                        activity.pic = imgsUrl;


                        if (m_activityBLL.SaveChange())
                        {
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，activity信息的Id为" + bid, "activity",
                                Result.Succeed);//写入日志                           
                            //return Json(Suggestion.UpdateSucceed); //提示更新成功 
                        }
                        else
                        {
                            string returnValue = string.Empty;  
                            if (validationErrors != null && validationErrors.Count > 0)
                            {
                                validationErrors.All(a =>
                                {
                                    returnValue += a.ErrorMessage;
                                    return true;
                                });
                            }
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，activity信息的Id为" + bid + "," + returnValue, "activity",
                                Result.Fail);//写入日志                           
                            //return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                        }
                            break;
                        case 3:
                            food_list = m_food_listBLL.GetById(bid);
                           imgsUrl = food_list.pic;
                        imgsUrl = imgsUrl + fileName+";";
                        food_list.pic = imgsUrl;


                        if (m_food_listBLL.SaveChange())
                        {
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，food_list信息的Id为" + bid, "food_list",
                                Result.Succeed);//写入日志                           
                            //return Json(Suggestion.UpdateSucceed); //提示更新成功 
                        }
                        else
                        {
                            string returnValue = string.Empty;  
                            if (validationErrors != null && validationErrors.Count > 0)
                            {
                                validationErrors.All(a =>
                                {
                                    returnValue += a.ErrorMessage;
                                    return true;
                                });
                            }
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，food_list信息的Id为" + bid + "," + returnValue, "food_list",
                                Result.Fail);//写入日志                           
                            //return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                        }
                            break;
                        case 4:
                            youhui = m_youhuiBLL.GetById(bid);
                    imgsUrl = youhui.pic;
                        imgsUrl = imgsUrl + fileName+";";
                        youhui.pic = imgsUrl;


                        if (m_food_listBLL.SaveChange())
                        {
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，youhui信息的Id为" + bid, "youhui",
                                Result.Succeed);//写入日志                           
                            //return Json(Suggestion.UpdateSucceed); //提示更新成功 
                        }
                        else
                        {
                            string returnValue = string.Empty;  
                            if (validationErrors != null && validationErrors.Count > 0)
                            {
                                validationErrors.All(a =>
                                {
                                    returnValue += a.ErrorMessage;
                                    return true;
                                });
                            }
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，youhui信息的Id为" + bid + "," + returnValue, "youhui",
                                Result.Fail);//写入日志                           
                            //return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                        }
                            break;
                        case 5:
                            room_price = m_room_priceBLL.GetById(bid);
                    imgsUrl = room_price.pic;
                        imgsUrl = imgsUrl + fileName+";";
                        room_price.pic = imgsUrl;


                        if (m_food_listBLL.SaveChange())
                        {
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateSucceed + "，room_price信息的Id为" + bid, "room_price",
                                Result.Succeed);//写入日志                           
                            //return Json(Suggestion.UpdateSucceed); //提示更新成功 
                        }
                        else
                        {
                            string returnValue = string.Empty;  
                            if (validationErrors != null && validationErrors.Count > 0)
                            {
                                validationErrors.All(a =>
                                {
                                    returnValue += a.ErrorMessage;
                                    return true;
                                });
                            }
                            LogClassModels.WriteServiceLog(LogType.Operation, Suggestion.UpdateFail + "，room_price信息的Id为" + bid + "," + returnValue, "room_price",
                                Result.Fail);//写入日志                           
                            //return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                        }
                            break;
                        default:
                            break;
                    }


                }
                catch
                {

                }
            }
            return Content(fileName);
        }
        #endregion


    }
}
