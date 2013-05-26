using System.Linq;
using System.Web.Mvc;

using DAL;
using App.Models;
using BLL;
using System.Drawing;
using System;
using System.Drawing.Imaging;

namespace App.Controllers
{
    /// <summary>
    /// 用户账户信息
    /// </summary>
    [HandleError]
    public class AccountController : BaseController
    {
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
#if DEBUG
            //Debug 测试时使用
            Account account = new Account();
            account.PersonName = "Admin";
            account.Id = "ac12e49f-ad2d-4271-ae85-d614c334e7e9";
            Session["account"] = account;
            return RedirectToAction("Index", "Home");
#else
            //Release 正式平台使用
            return View();
#endif
        }
        /// <summary>
        /// 点击 登录系统 后返回
        /// </summary>
        /// <param name="model">登录信息</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(LogOnModel model)
        {
            #region 验证码验证

            if (Session["__VCode"] == null || (Session["__VCode"] != null && model.ValidateCode != Session["__VCode"].ToString()))
            {
                ModelState.AddModelError("PersonName", "验证码错误！"); //return "";
                return View();
            }
            #endregion

            if (ModelState.IsValid)
            {
                string accountId = AccountBLL.ValidateUser(model.PersonName, model.Password);
                if (!string.IsNullOrWhiteSpace(accountId))
                {//登录成功
                    Account account = new Account();
                    account.PersonName = model.PersonName;
                    account.Id = accountId;
                    Session["account"] = account;

                    LoginUserManage.Add(Session.SessionID, account.PersonName);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("PersonName", "用户名或者密码出错。");
            return View();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            if (Session["account"] != null)
            {
                Session["account"] = null;
            }
            return RedirectToAction("Index", "Account");
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            string currentPerson = GetCurrentPerson();
            ViewBag.PersonNamea = currentPerson;
            if (string.IsNullOrWhiteSpace(currentPerson))
            {
                ModelState.AddModelError("", "对不起，请重新登陆");
            }
            return View();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">修改密码的模型</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            string currentPerson = GetCurrentPerson();
            ViewBag.PersonNamea = currentPerson;
            if (string.IsNullOrWhiteSpace(currentPerson))
            {
                ModelState.AddModelError("", "对不起，请重新登陆");
                return View();
            }
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(AccountBLL.ValidateUser(currentPerson, model.OldPassword)))
                {
                    if (AccountBLL.ChangePassword(currentPerson, model.OldPassword, model.NewPassword))
                    {
                        ModelState.AddModelError("", "修改密码成功");
                        return View();
                    }
                }
            }
            ModelState.AddModelError("", "修改密码不成功，请核实数据");
            return View();
        }

        public void ValidateCode()
        {
            // 在此处放置用户代码以初始化页面
            string vnum;
            vnum = GetByRndNum(4);
            Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
            Response.ContentType = "image/jpeg";

            CreateValidateCode(vnum);

        }

        private void CreateValidateCode(string vnum)
        {
            Bitmap Img = null;
            Graphics g = null;
            Random random = new Random();
            int gheight = vnum.Length * 15;
            Img = new Bitmap(gheight, 24);
            g = Graphics.FromImage(Img);
            Font f = new Font("宋体", 14, FontStyle.Bold);
            //Font f = new Font("宋体", 9, FontStyle.Bold);

            g.Clear(Color.White);//设定背景色
            Pen blackPen = new Pen(ColorTranslator.FromHtml("#BCBCBC"), 3);

            for (int i = 0; i < 128; i++)// 随机产生干扰线，使图象中的认证码不易被其它程序探测到
            {
                int x = random.Next(gheight);
                int y = random.Next(20);
                int xl = random.Next(6);
                int yl = random.Next(2);
                g.DrawLine(blackPen, x, y, x + xl, y + yl);
            }

            SolidBrush s = new SolidBrush(ColorTranslator.FromHtml("#411464"));
            g.DrawString(vnum, f, s, 3, 3);

            //画边框
            blackPen.Width = 1;
            g.DrawRectangle(blackPen, 0, 0, Img.Width - 1, Img.Height - 1);
            Img.Save(Response.OutputStream, ImageFormat.Jpeg);
            s.Dispose();
            f.Dispose();
            blackPen.Dispose();
            g.Dispose();
            Img.Dispose();

            //Response.End();
        }

        //-----------------给定范围获得随机颜色------------
        Color GetByRandColor(int fc, int bc)
        {
            Random random = new Random();

            if (fc > 255)
                fc = 255;
            if (bc > 255)
                bc = 255;
            //if(ac>255) ac=255;
            int r = fc + random.Next(bc - fc);
            int g = fc + random.Next(bc - fc);
            int b = fc + random.Next(bc - bc);
            Color rs = Color.FromArgb(r, g, b);
            return rs;
        }

        //-----------------------取随机产生的认证码(6位数字)
        public string GetByRndNum(int VcodeNum)
        {

            string VNum = "";

            Random rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                VNum += VcArray[rand.Next(0, 9)];
            }

            //MySession.setSession("VCode", VNum);
            //VNum = CE.Marketing.Framework.FrameworkManager.Tools.GenerateProverb();
            Session["__VCode"] = VNum;
            return VNum;
        }
        private static readonly string[] VcArray = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    }

}
