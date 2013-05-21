﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;
using System.IO;

namespace BLL
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public static class ExceptionsHander
    {
        /// <summary>
        /// 将异常信息写入数据库，或者文本文件
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteExceptions(Exception ex)
        {
            bool exceptionEnabled = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ExceptionEnabled"]);
            if (!exceptionEnabled)
            {
                return;
            }
            SysException sysException = new SysException();
            sysException.CreateTime = DateTime.Now;
            sysException.Remark = ex.StackTrace;
            sysException.Message = ex.Message + " | " + ex.InnerException.Message;
            sysException.LeiXing = "异常";
            sysException.Result = "成功捕获";
            sysException.Id = Result.GetNewId();
            try
            {
                using (SysExceptionBLL sysExceptionRepository = new SysExceptionBLL())
                {
                    ValidationErrors validationErrors = new ValidationErrors();
                    sysExceptionRepository.Create(ref validationErrors, sysException);
                    return;
                }
            }
            catch (Exception ep)
            {
                try
                {
                    string path = @"mylog.txt";
                    string txtPath = System.Web.HttpContext.Current.Server.MapPath(path);//获取绝对路径
                    using (StreamWriter sw = new StreamWriter(txtPath, true, Encoding.Default))
                    {
                        sw.WriteLine((ex.Message + "|" + ex.StackTrace + "|" + ep.Message + "|" + DateTime.Now.ToString()).ToString());
                        sw.Close();
                    }
                    return;
                }
                catch { return; }
            }

        }
    }
}
