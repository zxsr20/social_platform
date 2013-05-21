using System.Linq;
using System.Web.Mvc;

using DAL;
using BLL;
using System.Text;
namespace App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            #region  正式发布 获取菜单
            if (Session["account"] == null)
                return RedirectToAction("Index", "Account");

            Account account = (Account)Session["account"];
            ViewData["PersonName"] = account.PersonName;
            using (HomeBLL home = new HomeBLL())
            {
                string menuStr = home.GetMenuByPersonId(account.Id);
                if (!string.IsNullOrEmpty(menuStr) && menuStr.Length > 9)
                {
                    ViewData["Menu"] = menuStr;
                }
                else
                {
                    ViewData["Menu"] = string.Empty; ;
                }
            }
            #endregion
            return View();
        }
        /// <summary>
        /// 根据父节点获取数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetSysFieldByParentId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            using (BaseDDL baseDDL = new BaseDDL())
            {
                return Json(new SelectList(baseDDL.GetSysFieldByParentId(id), "Id", "MyTexts"), JsonRequestBehavior.AllowGet);
            }

        }
    }
}
