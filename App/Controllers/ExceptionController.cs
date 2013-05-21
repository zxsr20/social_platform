using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;
namespace App.Controllers
{
    public class ExceptionController : Controller
    {
        public ActionResult Index()
        {
            BaseException ex = new BaseException();
            return View(ex);
        }

    }
}
