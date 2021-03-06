﻿using System;
using System.Linq;
using System.Collections.Generic;
using DAL;
using BLL;
using Common;
using System.Web.Mvc;
using App.Models;

namespace App.Controllers
{
    /// <summary>
    /// 部门树形结构
    /// </summary>
    public class SysDepartmentTreeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取树形页面的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTree()
        {
            List<SystemTree> listSystemTree = new List<SystemTree>();
            string parentId = Request["parentid"];//父节点编号;
            using (SysDepartmentBLL db = new SysDepartmentBLL())
            {
                SysDepartmentTreeNodeCollection tree = new SysDepartmentTreeNodeCollection();
                var trees = db.GetAll().OrderBy(o => o.Sort);
                if (trees != null)
                {
                    tree.Bind(trees, parentId, ref listSystemTree);
                }
            }
            return Json(listSystemTree, JsonRequestBehavior.AllowGet);
        }
    }
}

