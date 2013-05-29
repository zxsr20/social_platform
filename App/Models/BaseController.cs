using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common;
using C1.C1Excel;
using DAL;
using BLL;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;

namespace App.Models
{
    //[SupportFilter]
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取当前登陆人
        /// </summary>
        /// <returns></returns>
        public string GetCurrentPerson()
        {
            Account account = GetCurrentAccount();
            if (account != null && !string.IsNullOrWhiteSpace(account.PersonName))
            {
                return account.PersonName;
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        public Account GetCurrentAccount()
        {
            if (Session["account"] != null)
            {
                Account account = (Account)Session["account"];
                return account;
            }
            return null;
        }

        public void addUserFilter(FlexigridParam param)
        {
            #region 添加用户id过滤
            if (GetCurrentPerson().ToLower() != "admin")
            {
                if (param.Query == null || param.Query == "")
                {
                    param.Query = "userid&" + GetCurrentPerson();
                }
                else
                {
                    param.Query = param.Query + "^userid&" + GetCurrentPerson();
                }
            }
            #endregion
        }
        /// <summary>
        /// 全局的异常处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            // 此处进行异常记录，可以记录到数据库或文本，也可以使用其他日志记录组件。
            // 通过filterContext.Exception来获取这个异常。

            ExceptionsHander.WriteExceptions(filterContext.Exception);  
            // 执行基类中的OnException
            //base.OnException(filterContext);

            // 重定向到异常显示页或执行其他异常处理方法
            RedirectToAction("Account");   
        }
        public BaseController()
        {   }
        public string Prompt(string title, string message, string returnUrl, params object[] par)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = "提示信息";
            }
            if (string.IsNullOrEmpty(title))
            {
                message = "提示信息";
            }
            return (@"     
        $('    <div id=@dialo@ title=@" + title + @"@>" + message + @"</div>').dialog({
                    autoOpen: true,
                    buttons: {
                        @继续操作@: function () {
                            $(this).dialog(@close@);
                        },
                        @返回列表@: function () {
                        window.location.href = @../../returnUrl@;
 
                            $(this).dialog(@close@);
                        }
                    }
                });    
      
     ").Replace('@', '"').Replace("returnUrl", returnUrl);
        }
        public string Prompt(string message)
        {
            return Prompt(message, message, "");

        }
        public string PromptEdit(string title, string message, string returnUrl, params object[] par)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = "提示信息";
            }
            if (string.IsNullOrEmpty(title))
            {
                message = "提示信息";
            }
            return (@"    
            function callback(e,ui) {            
                  window.location.href = @../../returnUrl@;
            } 
            $('    <div id=@dialo@ title=@" + title + @"@>" + message + @"</div>').dialog({
                    autoOpen: true,
                    close:callback,
                    buttons: {                       
                        @返回列表@: function () {
                        window.location.href = @../../returnUrl@;
 
                            $(this).dialog(@close@);
                        }
                    }
                });    
      
     ").Replace('@', '"').Replace("returnUrl", returnUrl);
        }
    
        public string WriteExcle(FlexigridParam param, dynamic[] query, int from = 1)
        {
            var names = param.QType.GetString().Split(',');
            var cols = param.Cols.GetString().Split(',');
            C1XLBook _book = new C1XLBook();
            string path = @"~/Files/a.xls";
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);
            _book.Load(xlsPath);
            string guid = Guid.NewGuid().ToString();
            string saveFileName = xlsPath.Path(guid);
            XLSheet sheet = _book.Sheets[0];
            XLCell cell = sheet[0, 0];
            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            for (int i = 0; i < names.Length; i++)
            {
                cell = sheet[0, i];
                if (!string.IsNullOrWhiteSpace(names[i]))
                {
                    cell.Value = names[i]; //列值
                }
            }
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                cols.All(a =>
                {
                    cell = sheet[i + from, j];
                    if (propertyName.ContainsKey(a)) //列名
                    {
                        cell.Value = propertyName[a]; //列值
                    }
                    j++;
                    return true;
                });
            }
            _book.Save(saveFileName);
            LogClassModels.WriteServiceLog(LogType.Operation, string.Format("../../../Files/{0}.xls", guid) + "，", "导出数据",
                Result.Succeed);//写入日志
            return string.Format("../../../Files/{0}.xls", guid); //path.Replace("b",guid);
        }
    }
}