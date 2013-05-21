using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using DAL;
using System.Web.Mvc;

namespace BLL
{
    public abstract class BaseManyBLL:IDisposable
    {
        public string Start_Time { get { return "Start_Time"; } }
        public string End_Time { get { return "End_Time"; } }
        public string Start_Int { get { return "Start_Int"; } }
        public string End_Int { get { return "End_Int"; } }
        public void GetDiffrent(List<string> newId, List<string> oldId, ref List<string> addId, ref List<string> deleteId)
        {
            addId = (from n in newId
                     where !oldId.Contains(n)
                     where n.Length == 36
                     select n).ToList();
            deleteId = (from o in oldId
                        where !newId.Contains(o)
                        where o.Length == 36
                        select o).ToList();
        }
        ///// <summary>
        ///// 获取字段，首选默认
        ///// </summary>
        ///// <returns></returns>
        //public List<SelectListItem> GetSysField(string table, string colum)
        //{
        //    using (SysEntities db = new SysEntities())
        //    {
        //        return (from m in db.SysField
        //                where m.Tables == table
        //                where m.Colums == colum
        //                orderby m.Sort ascending
        //                select new SelectListItem { Text = m.Values, Value = m.Values }).Distinct().ToList();
        //    }
        //}
        ///// <summary>
        ///// 获取字段，首选默认
        ///// </summary>
        ///// <returns></returns>
        //public List<SelectListItem> GetSysField(string table, string colum, string value)
        //{
        //    using (SysEntities db = new SysEntities())
        //    {
        //        return (from m in db.SysField
        //                where m.Tables == table
        //                where m.Colums == colum
        //                orderby m.Sort
        //                select new SelectListItem { Text = m.Values, Value = m.Values, Selected = (m.Values == value) ? true : false }).Distinct().ToList();
        //    }
        //}

        public void Dispose()
        {
            
        }
    }
}
