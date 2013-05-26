using System.Collections.Generic;
using System.Linq;
using DAL;
using System.Web.Mvc;
using BLL;
namespace App.Models
{
    public class SysFieldModels 
    {
	/// <summary>
        /// 获取字段，首选默认
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysField(string table, string colum,string parentId)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum) || string.IsNullOrWhiteSpace(parentId))
            {
                return null;
            }
            using (BaseDDL baseDDL = new BaseDDL())
            {
                return new SelectList(baseDDL.GetSysField(table, colum,parentId), "Id", "MyTexts");
            }
        }
        /// <summary>
        /// 获取字段，首选默认
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysField(string table, string colum)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                return null;
            }
            using (BaseDDL baseDDL = new BaseDDL())
            { 
                return new SelectList(baseDDL.GetSysField(table, colum), "Id", "MyTexts");
            }
        }

        /// <summary>
        /// 根据主键id，获取数据字典的展示字段
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        public static string GetMyTextsById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return string.Empty;
            }
            using (BaseDDL baseDDL = new BaseDDL())
            {
                return baseDDL.GetMyTextsById(id);
            }
        }
    }
}