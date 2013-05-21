using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using DAL;
using System.Web.Mvc;
using Common;

namespace BLL
{
    public abstract class BaseBLL : IDisposable
    {
        protected SysEntities db = new SysEntities();
        /// <summary>
        /// 合并子模块节点
        /// </summary>
        /// <param name="parent">父节点</param>
        /// <returns>包含所有父节点和子节点的数据</returns>
        public List<string> MergeChildren(List<string> parent)
        {
            List<string> items = new List<string>();

            foreach (string parentId in parent)
            {
                List<string> tempItem = FindChildren(parentId);
                items = items.Union(tempItem).ToList();
            }

            return parent.Union(items).ToList();
        }

        /// <summary>
        /// 查询子模块节点数据。
        /// </summary>
        /// <param name="parentId">父节点编号</param>
        /// <returns>所有子模块节点数据</returns>
        public List<string> FindChildren(string parentId)
        {
            List<string> children = new List<string>();

            var menus = (from m in db.SysMenu
                         where m.ParentId == parentId
                         select m.Id).ToList();
            children = children.Union(menus).ToList();
            foreach (string id in menus)
            {
                List<string> cMenus = FindChildren(id);
                children = children.Union(cMenus).ToList();
            }

            return children;
        }
        /// <summary>
        /// 多对多数据关系中，主键为string类型
        /// </summary>
        /// <param name="newId">新的主键</param>
        /// <param name="oldId">已有的主键</param>
        /// <param name="addId">新增加的主键</param>
        /// <param name="deleteId">删除的主键</param>
        public void GetDiffrent(List<string> newId, List<string> oldId, ref List<string> addId, ref List<string> deleteId)
        {
            addId = (from n in newId
                     where oldId.All(a => (a != n))
                     where !string.IsNullOrWhiteSpace(n)
                     select n).ToList();

            deleteId = (from o in oldId
                        where newId.All(a => (a != o))
                        where !string.IsNullOrWhiteSpace(o)
                        select o).ToList();
        }
        /// <summary>
        /// 多对多数据关系中，主键为int类型
        /// </summary>
        /// <param name="newId">新的主键</param>
        /// <param name="oldId">已有的主键</param>
        /// <param name="addId">新增加的主键</param>
        /// <param name="deleteId">删除的主键</param>
        public void GetDiffrentInt(List<string> newId, List<string> oldId, ref List<int> addId, ref List<int> deleteId)
        {
            addId = (from n in newId
                     where oldId.All(a => (a != n))
                     where !string.IsNullOrWhiteSpace(n)
                     select Convert.ToInt32(n)).ToList();

            deleteId = (from o in oldId
                        where newId.All(a => (a != o))
                        where !string.IsNullOrWhiteSpace(o)
                        select Convert.ToInt32(o)).ToList();
        }
        public void Dispose()
        {
            db.Dispose();   
        }
    }
}
