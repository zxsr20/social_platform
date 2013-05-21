using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace DAL
{
    /// <summary>
    /// daily
    /// </summary>
    public class dailyRepository : BaseRepository,IDisposable 
    {
        /// <summary>
        /// 获取所有daily
        /// </summary>
        /// <returns>daily集合</returns>
        public IQueryable<daily> GetAll()
        {
            using (SysEntities db = new SysEntities())
            {
                return GetAll(db);
            }
        }
        /// <summary>
        /// 获取所有daily
        /// </summary>
        /// <returns>daily集合</returns>
        public IQueryable<daily> GetAll(SysEntities db)
        {
            return db.daily.AsQueryable();
        }
        /// <summary>
        /// 导出Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        // <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<daily> DaoChuData(SysEntities db, FlexigridParam param, params object[] listQuery)
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
                    
                    if (queryDic.ContainsKey("userid") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "userid")
                    {//查询一对多关系的列名
                        where += "it.userid is null";
                        continue;
                    }
                    if (queryDic.ContainsKey("tasktype") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "tasktype")
                    {//查询一对多关系的列名
                        where += "it.tasktype is null";
                        continue;
                    }
                    if (queryDic.ContainsKey("status") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "status")
                    {//查询一对多关系的列名
                        where += "it.status is null";
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
            return db.daily
                     .Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it." + param.SortName.GetString() + " " + param.SortOrder.GetString())
                     .AsQueryable();   

        }
        /// <summary>
        /// 通过主键id，获取daily---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>daily</returns>
        public daily GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取daily---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>daily</returns>
        public daily GetById(SysEntities db, string id)
        { 
            return db.daily.SingleOrDefault(s => s.id == id);
        
        }
        /// <summary>
        /// 创建一个daily
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要创建的一个daily</param>
        public void Create(SysEntities db, daily entity)
        {
            if (entity != null)
            { 
                db.daily.AddObject(entity);
            }             
        }
        /// <summary>
        /// 创建一个daily
        /// </summary>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        public int Create(daily entity)
        {
            using (SysEntities db = new SysEntities())
            {
                Create(db, entity);
                return this.Save(db);
            }
        } 
        /// <summary>
        /// 创建daily对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Create(SysEntities db, IQueryable<daily> entitys)
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
        /// 删除一个daily
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条daily的主键</param>
        public void Delete(SysEntities db, string id)
        {
            daily deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.daily.DeleteObject(deleteItem);
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
            IQueryable<daily> collection = from f in db.daily
                    where deleteCollection.Contains(f.id)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.daily.DeleteObject(deleteItem);
            }
        }
        /// <summary>
        /// 编辑一个daily对象
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要编辑的一个daily对象</param>
        public daily Edit(SysEntities db, daily entity)
        {           
            db.daily.Attach(entity);
            db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);         
            return entity;
        }
        /// <summary>
        /// 编辑daily对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Edit(SysEntities db, IQueryable<daily> entitys)
        {
            foreach (daily entity in entitys)
            {
                this.Edit(db, entity);
            }
        }

        /// <summary>
        /// 根据userid，获取所有daily数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<daily> GetByRefuserid(SysEntities db, string id)
        {
            return from c in db.daily
                        where c.userid == id
                        select c;
                      
        }

        /// <summary>
        /// 根据tasktype，获取所有daily数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<daily> GetByReftasktype(SysEntities db, string id)
        {
            return from c in db.daily
                        where c.tasktype == id
                        select c;
                      
        }

        /// <summary>
        /// 根据status，获取所有daily数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<daily> GetByRefstatus(SysEntities db, string id)
        {
            return from c in db.daily
                        where c.status == id
                        select c;
                      
        }

        public void Dispose()
        {            
        }
    }
}

