using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

namespace App
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Account", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }
	    public void ExceptionHandlerStarter()
        {
            String exMode = ConfigurationManager.AppSettings["ExceptionMode"];
            if (!String.IsNullOrEmpty(exMode) && string.Compare(exMode.ToLower(), "on") == 0)
            {
                string s = HttpContext.Current.Request.Url.ToString();
                HttpServerUtility server = HttpContext.Current.Server;
                if (server.GetLastError() != null)
                {
                    Exception lastError = server.GetLastError();
                    Application["LastError"] = lastError;
                    int statusCode = HttpContext.Current.Response.StatusCode;
                    string exceptionOperator = ConfigurationManager.AppSettings["ExceptionUrl"];
                    try
                    {
                        if (!String.IsNullOrEmpty(exceptionOperator))
                        {
                            exceptionOperator = new System.Web.UI.Control().ResolveUrl(exceptionOperator);
                            string url = string.Format("{0}?ErrorUrl={1}", exceptionOperator, server.UrlEncode(s));
                            string script = String.Format("<script language='javascript' type='text/javascript'>window.top.location='{0}';</script>", url);
                            Response.Write(script);
                            Response.End();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            ExceptionHandlerStarter();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}