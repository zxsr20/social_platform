using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace DAL
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public class SysExceptionRepository : BaseRepository,IDisposable 
    {
        /// <summary>
        /// 获取所有异常处理
        /// </summary>
        /// <returns>异常处理集合</returns>
        public IQueryable<SysException> GetAll()
        {
            using (SysEntities db = new SysEntities())
            {
                return GetAll(db);
            }
        }
        /// <summary>
        /// 获取所有异常处理
        /// </summary>
        /// <returns>异常处理集合</returns>
        public IQueryable<SysException> GetAll(SysEntities db)
        {
            return db.SysException.AsQueryable();
        }
        /// <summary>
        /// 导出Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        // <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<SysException> DaoChuData(SysEntities db, FlexigridParam param, params object[] listQuery)
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
            return db.SysException
                     .Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it." + param.SortName.GetString() + " " + param.SortOrder.GetString())
                     .AsQueryable();   

        }
        /// <summary>
        /// 通过主键id，获取异常处理---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>异常处理</returns>
        public SysException GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取异常处理---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>异常处理</returns>
        public SysException GetById(SysEntities db, string id)
        { 
            return db.SysException.SingleOrDefault(s => s.Id == id);
        
        }
        /// <summary>
        /// 创建一个异常处理
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要创建的一个异常处理</param>
        public void Create(SysEntities db, SysException entity)
        {
            if (entity != null)
            { 
                db.SysException.AddObject(entity);
            }             
        }
        /// <summary>
        /// 创建一个异常处理
        /// </summary>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        public int Create(SysException entity)
        {
            using (SysEntities db = new SysEntities())
            {
                Create(db, entity);
                return this.Save(db);
            }
        } 
        /// <summary>
        /// 创建异常处理对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Create(SysEntities db, IQueryable<SysException> entitys)
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
        /// 删除一个异常处理
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条异常处理的主键</param>
        public void Delete(SysEntities db, string id)
        {
            SysException deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.SysException.DeleteObject(deleteItem);
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
            IQueryable<SysException> collection = from f in db.SysException
                    where deleteCollection.Contains(f.Id)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.SysException.DeleteObject(deleteItem);
            }
        }
        /// <summary>
        /// 编辑一个异常处理对象
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要编辑的一个异常处理对象</param>
        public SysException Edit(SysEntities db, SysException entity)
        {           
            db.SysException.Attach(entity);
            db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);         
            return entity;
        }
        /// <summary>
        /// 编辑异常处理对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Edit(SysEntities db, IQueryable<SysException> entitys)
        {
            foreach (SysException entity in entitys)
            {
                this.Edit(db, entity);
            }
        }

        public void Dispose()
        {            
        }
    }
}

