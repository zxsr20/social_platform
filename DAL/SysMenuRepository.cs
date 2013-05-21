using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace DAL
{
    /// <summary>
    /// 模块
    /// </summary>
    public class SysMenuRepository : BaseRepository,IDisposable 
    {
        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns>模块集合</returns>
        public IQueryable<SysMenu> GetAll()
        {
            using (SysEntities db = new SysEntities())
            {
                return GetAll(db);
            }
        }
        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns>模块集合</returns>
        public IQueryable<SysMenu> GetAll(SysEntities db)
        {
            return db.SysMenu.AsQueryable();
        }
        /// <summary>
        /// 导出Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        // <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<SysMenu> DaoChuData(SysEntities db, FlexigridParam param, params object[] listQuery)
        {
            string where = string.Empty;
            int flagWhere = 0;

            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(param.Query.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {
                    if (flagWhere != 0)
                    {
                        where += " and ";
                    }
                    flagWhere++;
                    //if (false)//个性化的东西在循环内部排添加
                    //{//必须有where条件  
                    //    if (queryDic.ContainsKey("Name") && queryDic.ContainsValue("Clark")) { }//需要查询的列名
                    //    where += "it." + item.Key + " like '%" + item.Value + "%'";
                    //    continue;
                    //}
                    
                    if (queryDic.ContainsKey("ParentId") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "ParentId")
                    {//查询一对多关系的列名
                        where += "it.ParentId is null";
                        continue;
                    }
                    
                    if (queryDic.ContainsKey("SysRole")&& !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "SysRole")
                    {//查询多对多关系的列名
                        where += "EXISTS(select p from it.SysRole as p where p.Id='" + item.Value + "')";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Time)) //需要查询的列名
                     {
                         where += "it. " + item.Key.Remove(item.Key.IndexOf(Start_Time)) + " >=  CAST('" + item.Value + "' as   System.DateTime)";
                         continue;
                     }
                     if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Time)) //需要查询的列名
                     {
                         where += "it." + item.Key.Remove(item.Key.IndexOf(End_Time)) + " <  CAST('" + Convert.ToDateTime(item.Value).AddDays(1) + "' as   System.DateTime)";
                         continue;
                     }
                     if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Int)) //需要查询的列名
                     {
                         where += "it." + item.Key.Remove(item.Key.IndexOf(Start_Int)) + " >= " + item.Value.GetInt();
                         continue;
                     }
                     if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Int)) //需要查询的列名
                     {
                         where += "it." + item.Key.Remove(item.Key.IndexOf(End_Int)) + " <= " + item.Value.GetInt();
                         continue;
                     }

                     if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_String)) //需要查询的列名
                     {
                         where += "it." + item.Key.Remove(item.Key.IndexOf(End_String)) + " = '" + item.Value +"'";
                         continue;
                     }

                     if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(DDL_String)) //需要查询的列名
                     {
                         where += "it." + item.Key.Remove(item.Key.IndexOf(DDL_String)) + " = '" + item.Value +"'";
                         continue;
                     }
                    where += "it." + item.Key + " like '%" + item.Value + "%'";
                }
            }
            return db.SysMenu
                     .Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it." + param.SortName.GetString() + " " + param.SortOrder.GetString())
                     .AsQueryable();   

        }
        /// <summary>
        /// 通过主键id，获取模块---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>模块</returns>
        public SysMenu GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取模块---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>模块</returns>
        public SysMenu GetById(SysEntities db, string id)
        { 
                 return db.SysMenu.SingleOrDefault(s => s.Id == id); 
        }
        
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<SysRole> GetRefSysRole(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetRefSysRole(db, id);
            }
        }
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<SysRole> GetRefSysRole(SysEntities db, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return from m in db.SysMenu
                       from f in m.SysRole
                       where m.Id == id
                       select f;
            }
            return null;
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<SysRole> GetRefSysRole(SysEntities db)
        {
            return from m in db.SysMenu
                   from f in m.SysRole
                   select f;
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<SysRole> GetRefSysRole()
        {
            using (SysEntities db = new SysEntities())
            {
                return GetRefSysRole(db);
            }
        }

        /// <summary>
        /// 创建一个模块
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要创建的一个模块</param>
        public void Create(SysEntities db, SysMenu entity)
        {
            if (entity != null)
            { 
                db.SysMenu.AddObject(entity);
            }             
        }
        /// <summary>
        /// 创建一个模块
        /// </summary>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        public int Create(SysMenu entity)
        {
            using (SysEntities db = new SysEntities())
            {
                Create(db, entity);
                return this.Save(db);
            }
        } 
        /// <summary>
        /// 创建模块对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Create(SysEntities db, IQueryable<SysMenu> entitys)
        {
            foreach (var entity in entitys)
            {
                this.Create(db, entity);
            }
        }
        /// <summary>
        /// 确定删除一个对象，调用Save方法
        /// </summary>
        /// <param name="id">一条数据的主键</param>
        /// <returns></returns>    
        public int Delete(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                this.Delete(db, id);
                return Save(db);
            }
        }
        /// <summary>
        /// 删除一个模块
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条模块的主键</param>
        public void Delete(SysEntities db, string id)
        {
            SysMenu deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.SysMenu.DeleteObject(deleteItem);
            }
        }
        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="deleteCollection">主键的集合</param>
        public void Delete(SysEntities db, string[] deleteCollection)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<SysMenu> collection = from f in db.SysMenu
                    where deleteCollection.Contains(f.Id)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.SysMenu.DeleteObject(deleteItem);
            }
        }
        /// <summary>
        /// 编辑一个模块对象
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要编辑的一个模块对象</param>
        public SysMenu Edit(SysEntities db, SysMenu entity)
        {            
            db.SysMenu.Attach(entity);
            db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);         
            return entity;
        }
        /// <summary>
        /// 编辑模块对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Edit(SysEntities db, IQueryable<SysMenu> entitys)
        {
            foreach (SysMenu entity in entitys)
            {
                this.Edit(db, entity);
            }
        }

        /// <summary>
        /// 根据ParentId，获取所有模块数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<SysMenu> GetByRefParentId(SysEntities db, string id)
        {
            return from c in db.SysMenu
                        where c.ParentId == id
                        select c;
                      
        }

        public void Dispose()
        {            
        }
    }
}

