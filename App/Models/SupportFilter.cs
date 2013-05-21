using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Web.UI;
using System.EnterpriseServices;
using System.ComponentModel;
using DAL;
using BLL;
using System.Web.Mvc;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.Routing;
namespace App.Models
{
    public class SupportFilter
    {
    }
    public class ActionPermission
    {
        /// <summary>
        /// 请求地址操作
        /// </summary>
        public virtual string ActionName { get; set; }

        /// <summary>
        /// 请求地址控制器
        /// </summary>
        public virtual string ControllerName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }
    }
    public class ExceptionLogAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // 此处进行异常记录 
            // 通过filterContext.Exception来获取这个异常。 
            BLL.ExceptionsHander.WriteExceptions(filterContext.Exception);
            base.OnException(filterContext);

            //filterContext.HttpContext.Response.Redirect("/");
        }
    }


    public class SupportFilterAttribute : ActionFilterAttribute
    {
        static bool IsSubClassOf(Type type, Type baseType)
        {
            var b = type.BaseType;
            while (b != null)
            {
                if (b.Equals(baseType))
                { return true; }
                b = b.BaseType;
            }
            return false;
        }
        
        /// <summary>
        /// 当Action中标注了[SupportFilter]的时候会执行
        /// </summary>
        /// <param name="filterContext">请求上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            Account account = filterContext.HttpContext.Session["account"] as Account;
            if (ValidateIsLogined(account) && !ValidateRelogin(account) && ValidatePermission(account))
            {//已经登陆，有权限，且没有单机登陆限制。
                return;
            }
            else
            {
                filterContext.Result = new EmptyResult();
                return;
            }
             /**/
            /*
            if (filterContext.HttpContext.Session["account"] == null)
            {
                filterContext.HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='Account'; </script>");
                filterContext.Result = new EmptyResult();
                return;
            }
            else
            {
                Account account = (Account)filterContext.HttpContext.Session["account"];
                if (account == null || string.IsNullOrWhiteSpace(account.Id))
                {
                    return;
                }
            }*/

        }
        public bool ValidatePermission(Account account)
        {
            bool bResult = true;
            /*
            if (account != null)
            {
                string url = HttpContext.Current.Request.Url.ToString().ToLower();
                List<string> permList = new SysPersonBLL().GetPermission(account.Id);//获取当前用户的权限路径列表 如:new List<string>();。
                foreach (string item in permList)
                {
                    if (url.Contains(item.ToLower()))
                    {//拥有权限，退出
                        bResult = true;
                        break;
                    }
                }

                if (bResult == false)
                {
                    string promptString = "权限不够无法访问该页,请与管理员联系！";
                    PromptScript(promptString, string.Empty);
                }
            }
            */
            return bResult;
        }
        /// <summary>
        /// 验证用户是否已经登陆
        /// </summary>
        /// <param name="account">验证的用户信息</param>
        /// <returns>验证结果（true:已登陆，false:未登陆）</returns>
        public bool ValidateIsLogined(Account account)
        {
            bool bResult = false;

            bResult = account != null;
            if (bResult == false)
            {
                string promptString = "用户尚未登陆或登陆会话丢失，如需进入系统请到登陆界面重新登陆！";
                string redirectLoginPage = GetLoginPage();
                PromptScript(promptString, redirectLoginPage, true);
            }

            return bResult;
        }
        /// <summary>
        /// 验证用户登陆是否有单机登陆的限制。
        /// </summary>
        /// <param name="account">验证用户信息</param>
        /// <returns>是否单机登陆限制(true:是，false:否)</returns>
        public bool ValidateRelogin(Account account)
        {
            bool bResult = false;

            if (account != null)
            {
                string isSingleLogin = ConfigurationManager.AppSettings["IsSingleLogin"];
                if (!String.IsNullOrEmpty(isSingleLogin) && isSingleLogin.ToLower() == "true")
                {
                    if (LoginUserManage.IsChange(HttpContext.Current.Session.SessionID, account.PersonName))
                    {//同一帐号在其它机器上登陆。
                        bResult = true;
                        string promptString = "本用户已经在另一台机器上登录，如需进入系统请到登陆界面重新登陆！";
                        string redirectLoginPage = GetLoginPage();
                        PromptScript(promptString, redirectLoginPage, true);
                    }
                }
            }

            return bResult;
        }

        /// <summary>
        /// 获取登陆首页
        /// </summary>
        /// <returns>登陆页URL</returns>
        private string GetLoginPage()
        {
            string redirectLoginPage = "/Account/Index";
            Route r = RouteTable.Routes["Default"] as Route;
            if (r != null)
            {
                redirectLoginPage = String.Format("/{0}/{1}", r.Defaults["controller"], r.Defaults["action"]);
            }

            return redirectLoginPage;
        }
        public void PromptScript(string message, string returnUrl, bool isTop)
        {
            String script = string.Empty;
            if (string.IsNullOrEmpty(returnUrl))
            {
                script = String.Format("<script language='javascript' type='text/javascript'>alert('{0}');</script>", message);
            }
            else if (isTop)
            {
                script = String.Format("<script language='javascript' type='text/javascript'>alert('{0}');window.top.location='{1}';</script>", message, returnUrl);
            }
            else
            {
                script = String.Format("<script language='javascript' type='text/javascript'>alert('{0}');window.location='{1}';</script>", message, returnUrl);
            }

            PromptScript(script);
        }
        public void PromptScript(string message, string returnUrl)
        {
            String script = string.Empty;
            if (string.IsNullOrEmpty(returnUrl))
            {
                script = String.Format("<script language='javascript' type='text/javascript'>alert('{0}');</script>", message);
            }
            else
            {
                script = String.Format("<script language='javascript' type='text/javascript'>alert('{0}');window.location='{1}';</script>", message, returnUrl);
            }

            PromptScript(script);
        }
        public void PromptScript(string script)
        {
            if (!String.IsNullOrEmpty(script))
            {
                HttpContext.Current.Response.Write(script);
                HttpContext.Current.Response.End();
            }
        }
    }
    public class LoginUserManage
    {
        /// <summary>
        /// 添加用户登陆信息
        /// </summary>
        /// <param name="sessID">SessionID</param>
        /// <param name="name">登陆名称</param>
        public static void Add(String sessID, String name)
        {
            NameValueCollection loginUsers = HttpContext.Current.Application["__LoginUsers"] as NameValueCollection;
            if (loginUsers == null)
            {
                loginUsers = new NameValueCollection();
            }
            loginUsers.Set(name, sessID);
            HttpContext.Current.Application["__LoginUsers"] = loginUsers;

        }
        /// <summary>
        /// 移除登陆信息
        /// </summary>
        /// <param name="name">登陆名称</param>
        public static void Remove(String name)
        {
            NameValueCollection loginUsers = HttpContext.Current.Application["__LoginUsers"] as NameValueCollection;
            if (loginUsers != null)
            {
                loginUsers.Remove(name);
            }
            HttpContext.Current.Application["__LoginUsers"] = loginUsers;
        }
        /// <summary>
        /// 登陆用户是否已经改变
        /// </summary>
        /// <param name="sessID">sessionID</param>
        /// <param name="name">登陆名称</param>
        /// <returns>结果(True:已改变,False:未改变)</returns>
        public static bool IsChange(String sessID, String name)
        {
            Boolean bResult = false;

            NameValueCollection loginUsers = HttpContext.Current.Application["__LoginUsers"] as NameValueCollection;
            if (loginUsers != null)
            {
                String oldSessID = loginUsers.GetValues(name)[0];
                if (!String.IsNullOrEmpty(oldSessID) && !sessID.Equals(oldSessID))
                {
                    bResult = true;
                }
            }

            return bResult;
        }
    }
}