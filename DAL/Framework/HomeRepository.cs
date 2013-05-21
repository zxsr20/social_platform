using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class HomeRepository
    {
        public string GetMenuByPersonId(string personId)
        {
            using (SysEntities db = new SysEntities())
            {
                StringBuilder strmenu = new StringBuilder();
                IQueryable<SysMenu> menuNeed =
                             (from m in db.SysMenu
                              from r in m.SysRole
                              from p in r.SysPerson                              
                              where (from f in db.SysField where f.MyTexts=="禁用" && f.MyTables=="SysMenu" && f.MyColums=="State" select f.Id).All(a=>a!=m.State)
                              where p.Id == personId
                              orderby m.Sort
                              select m).Distinct();
#if DEBUG
                //测试时使用
                //IQueryable<SysMenu> menuNeed = db.SysMenu;
#else
                //正式平台使用

#endif


                if (menuNeed != null && menuNeed.Any())
                {//拼接菜单的字符串                    
                    //一级节点
                    var menuid = from f in menuNeed
                                 where f.ParentId == null
                                 orderby f.Sort
                                 select f;
                    //二级节点
                    if (menuid != null && menuid.Any())
                    {
                        var menus = menuNeed.Except(menuid).OrderBy(o => o.Sort);

                        int flag = 0;
                        foreach (var item in menuid)
                        {
                            flag++;
                            string name = (string.IsNullOrWhiteSpace(item.Name) ? "" : item.Name);
                            string rootpath = string.IsNullOrWhiteSpace(item.Iconic) ? "" : "tu" + item.Iconic;
                            string str = "{@menuid@:@" + item.Id + "@,@icon@:@" + rootpath + "@,@menuname@:@" + name + "@,@menus@:[";

                            strmenu.Append(str);

                            var getmenu = GetMenus(item.Id, menus);
                            strmenu.Append(getmenu);

                            if (flag == menuid.Count())
                            {
                                strmenu.Append(@"]}");
                            }
                            else
                            {
                                strmenu.Append(@"]},");
                            }
                        }
                    }
                }
                return strmenu.ToString().Replace('@', '"');
            }
        }

        protected string GetMenus(string menuId, IQueryable<SysMenu> sysMenus)
        {
            var menus = from f in sysMenus
                        where f.ParentId == menuId
                        orderby f.Sort
                        select f;
            StringBuilder strmenu = new StringBuilder();
            int flag = 0;
            foreach (var item in menus)
            {
                flag++;

                string name = (string.IsNullOrWhiteSpace(item.Name) ? "" : item.Name);
                string rootpath = string.IsNullOrWhiteSpace(item.Iconic) ? "" : "tu" + item.Iconic;
                var url = string.IsNullOrEmpty(item.Url) ? "" : item.Url;
                string str = "{@menuid@:@" + item.Id + "@,@icon@:@" + rootpath + "@,@menuname@:@" + name + "@,@url@:@" + url + "@}";

                strmenu.Append(str);
                if (flag != menus.Count())
                {
                    strmenu.Append(@",");
                }
            }
            return strmenu.ToString();
        }
    }
}
