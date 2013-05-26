using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using DAL;
using BLL;
using System.Text;
namespace App.Models
{
    /// <summary>
    /// 部门
    /// </summary>
    public class SysDepartmentTreeNodeCollection
    {
        IEnumerable<SysDepartment> listTree;
        public void Bind(IEnumerable<SysDepartment> entitys, string myMyParentId, ref List<SystemTree> myChildren)
        {
            listTree = from o in entitys
                       where o.MyParentId == myMyParentId
                       select o;//叶子节点            
           
            foreach (var item in listTree)
            {
                SystemTree node = new SystemTree() { id = item.Id, text = item.Name };                   
                    
                if (entitys.Any(t => t.MyParentId == item.Id))
                {//包含子节点可以展示
                    node.state = "closed";
                }
                  
                myChildren.Add(node);
            }                
        }
    }
    public class SysDepartmentTree
    {
        IEnumerable<SysDepartment> listTree;
        public StringBuilder sb = new StringBuilder();
        public bool Bind(IEnumerable<SysDepartment> entitys, string parentId)
        {
            if (!string.IsNullOrEmpty(parentId))

                listTree = (from o in entitys
                            where o.MyParentId == parentId
                            select o);
            else
                listTree = (from o in entitys
                            where o.MyParentId == null
                            select o);

            //填充数据
            if (listTree != null && listTree.Any())
            {
                if (!string.IsNullOrWhiteSpace(parentId))
                {
                    SysDepartment t = entitys.Where(o => o.Id == parentId).FirstOrDefault();
                    if (t != null)
                    {
                        sb.Append(string.Format(@"<fieldset> <legend>  <input type=""checkbox""  onclick=""getfather('{0}')""  id=""{0}"" /><label for=""{0}"">{1}</label></legend>  <div class=""bigdivshowHeight""> ",
                            !string.IsNullOrWhiteSpace(t.Id) ? t.Id : "allmenus", !string.IsNullOrWhiteSpace(t.Name) ? t.Name : "全部部门"));

                    }
                }
                else
                {
                    sb.Append(string.Format(@"<fieldset  style="" width:748px; ""> <legend>
 <input type=""button""  onclick=""back()""  value=""返回列表"" />
 <input type=""button""  onclick=""save()""  value=""保存设置"" />
<input type=""button""  onclick=""allchecked1()""  value=""全部选择"" id=""{0}"" /> 
<input type=""button""  onclick=""allchecked0()"" value=""全部取消"" id=""unallmenus"" /> 
</legend> <div class=""bigdivshowHeight2""> 
", "allmenus", "全部选择"));

                }
                foreach (var item in listTree)
                {
                    if (Bind(entitys, item.Id))
                    {//递归调用 Bind
                        sb.Append(string.Format(@"   <input type=""checkbox""  onclick=""getson('{0}')""  id=""{0}"" /><label for=""{0}"">{1}</label>", item.Id, item.Name));
                    }
                }
                sb.Append(@"</div></fieldset>");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

