using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace DAL
{
    /// <summary>
    /// food_list
    /// </summary>
    public class food_listRepository : BaseRepository,IDisposable 
    {
        /// <summary>
        /// 获取所有food_list
        /// </summary>
        /// <returns>food_list集合</returns>
        public IQueryable<food_list> GetAll()
        {
            using (SysEntities db = new SysEntities())
            {
                return GetAll(db);
            }
        }
        /// <summary>
        /// 获取所有food_list
        /// </summary>
        /// <returns>food_list集合</returns>
        public IQueryable<food_list> GetAll(SysEntities db)
        {
            return db.food_list.AsQueryable();
        }
        /// <summary>
        /// 导出Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        // <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<food_list> DaoChuData(SysEntities db, FlexigridParam param, params object[] listQuery)
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
            return db.food_list
                     .Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it." + param.SortName.GetString() + " " + param.SortOrder.GetString())
                     .AsQueryable();   

        }
        /// <summary>
        /// 通过主键id，获取food_list---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>food_list</returns>
        public food_list GetById(int id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取food_list---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>food_list</returns>
        public food_list GetById(SysEntities db, int id)
        { 
            return db.food_list.SingleOrDefault(s => s.id == id);
        
        }
        /// <summary>
        /// 创建一个food_list
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要创建的一个food_list</param>
        public void Create(SysEntities db, food_list entity)
        {
            if (entity != null)
            { 
                db.food_list.AddObject(entity);
            }             
        }
        /// <summary>
        /// 创建一个food_list
        /// </summary>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        public int Create(food_list entity)
        {
            using (SysEntities db = new SysEntities())
            {
                Create(db, entity);
                return this.Save(db);
            }
        } 
        /// <summary>
        /// 创建food_list对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Create(SysEntities db, IQueryable<food_list> entitys)
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
        public int Delete(int id)
        {
            using (SysEntities db = new SysEntities())
            {
                this.Delete(db, id);
                return Save(db);
            }
        }
 
        /// <summary>
        /// 删除一个food_list
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条food_list的主键</param>
        public void Delete(SysEntities db, int id)
        {
            food_list deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.food_list.DeleteObject(deleteItem);
            }
        }
        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="deleteCollection">主键的集合</param>
        public void Delete(SysEntities db, int[] deleteCollection)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<food_list> collection = from f in db.food_list
                    where deleteCollection.Contains(f.id)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.food_list.DeleteObject(deleteItem);
            }
        }
        /// <summary>
        /// 编辑一个food_list对象
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要编辑的一个food_list对象</param>
        public food_list Edit(SysEntities db, food_list entity)
        {           
            db.food_list.Attach(entity);
            db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);         
            return entity;
        }
        /// <summary>
        /// 编辑food_list对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Edit(SysEntities db, IQueryable<food_list> entitys)
        {
            foreach (food_list entity in entitys)
            {
                this.Edit(db, entity);
            }
        }

        public void Dispose()
        {            
        }
    }
}

