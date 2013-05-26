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
    /// ^ReplaceClassMyTexts^
    /// </summary>
    public class SysFieldTreeNodeCollection
    {
        IEnumerable<SysField> listTree;
        public void Bind(IEnumerable<SysField> entitys, string myParentId, ref List<SystemTree> myChildren)
        {
            listTree = from o in entitys
                       where o.ParentId == myParentId
                       select o;//叶子节点            
           
            foreach (var item in listTree)
            {
                SystemTree node = new SystemTree() { id = item.Id, text = item.MyTexts };                   
                    
                if (entitys.Any(t => t.ParentId == item.Id))
                {//包含子节点可以展示
                    node.state = "closed";
                }
                  
                myChildren.Add(node);
            }                
        }
    }
    public class SysFieldTree
    {
        IEnumerable<SysField> listTree;
        public StringBuilder sb = new StringBuilder();
        public bool Bind(IEnumerable<SysField> entitys, string parentId)
        {
            if (!string.IsNullOrEmpty(parentId))

                listTree = (from o in entitys
                            where o.ParentId == parentId
                            select o);
            else
                listTree = (from o in entitys
                            where o.ParentId == null
                            select o);

            //填充数据
            if (listTree != null && listTree.Any())
            {
                if (!string.IsNullOrWhiteSpace(parentId))
                {
                    SysField t = entitys.Where(o => o.Id == parentId).FirstOrDefault();
                    if (t != null)
                    {
                        sb.Append(string.Format(@"<fieldset> <legend>  <input type=""checkbox""  onclick=""getfather('{0}')""  id=""{0}"" /><label for=""{0}"">{1}</label></legend>  <div class=""bigdivshowHeight""> ",
                            !string.IsNullOrWhiteSpace(t.Id) ? t.Id : "allmenus", !string.IsNullOrWhiteSpace(t.MyTexts) ? t.MyTexts : "全部^ReplaceClassMyTexts^"));

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
                        sb.Append(string.Format(@"   <input type=""checkbox""  onclick=""getson('{0}')""  id=""{0}"" /><label for=""{0}"">{1}</label>", item.Id, item.MyTexts));
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

