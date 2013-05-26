using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using DAL;
using BLL;
using Common;
using System.IO;
using System.Text;
namespace App.Models
{
    public class LogClassModels
    {
        public static void WriteServiceLog(string logType, string message, string menu, string result, LogOpration logOpration = LogOpration.Default)
        {
            try
            {
                 //logOpration设置优先级高于配置节logEnabled
                bool logEnabled = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogEnabled"]);
                if (logOpration == LogOpration.Fobid || (logOpration == LogOpration.Default && !logEnabled))
                {
                    return;
                }
                else if (logOpration == LogOpration.Start || (logOpration == LogOpration.Default && logEnabled))
                {
                    SysLog sysLog = new SysLog();
                    sysLog.CreateTime = DateTime.Now;
                    sysLog.Ip = GetIP();
                    sysLog.Message = message;
                    if (HttpContext.Current != null && HttpContext.Current.Session["account"] != null)
                    {
                        Account account = (Account)HttpContext.Current.Session["account"];
                        if (account != null && !string.IsNullOrWhiteSpace(account.PersonName))
                        {
                            sysLog.PersonId = account.PersonName;
                        }
                    }
                    else
                    {
                        sysLog.PersonId = "未登录用户";
                    }

                    sysLog.State = logType;
                    sysLog.Result = result;
                    sysLog.MenuId = menu;
                    sysLog.Id = Result.GetNewId();
                    using (SysLogBLL sysLogRepository = new SysLogBLL())
                    {
                        ValidationErrors validationErrors = new ValidationErrors();
                        sysLogRepository.Create(ref validationErrors, sysLog);
                        return;
                    }
                }
            }
            catch (Exception ep)
            {
                try
                {
                    string path = @"~/mylog.txt";
                    string txtPath = System.Web.HttpContext.Current.Server.MapPath(path);//获取绝对路径
                    using (StreamWriter sw = new StreamWriter(txtPath, true, Encoding.Default))
                    {
                        sw.WriteLine((ep.Message + "|" + logType + "|" + message + "|" + "MySession.Get(MySessionKey.UserID)" + "|" + GetIP() + DateTime.Now.ToString()).ToString());
                        sw.Close();
                    }
                    return;
                }
                catch { return; }
            }

        }
        public static string GetIP()
        {
            string ip = string.Empty;
            try
            {
                if (System.Web.HttpContext.Current != null)
                {
                    if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy
                    {
                        //得到真实的客户端地址
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString(); // Return real client IP.
                    }
                    else//如果没有使用代理服务器或者得不到客户端的ip not using proxy or can't get the Client IP
                    {

                        //得到服务端的地址要判断  System.Web.HttpContext.Current 为空的情况

                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.

                    }
                }
            }
            catch (Exception ep)
            {
                ip = "没有正常获取IP，" + ep.Message;
            }

            return ip;
        }

        public void Dispose()
        {

        }
    }
}