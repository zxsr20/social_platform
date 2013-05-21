﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace DAL
{
    /// <summary>
    /// 一对多中的多
    /// </summary>
    public class YiDuiDuoZhongDeDuoRepository : BaseRepository,IDisposable 
    {
        /// <summary>
        /// 获取所有一对多中的多
        /// </summary>
        /// <returns>一对多中的多集合</returns>
        public IQueryable<YiDuiDuoZhongDeDuo> GetAll()
        {
            using (SysEntities db = new SysEntities())
            {
                return GetAll(db);
            }
        }
        /// <summary>
        /// 获取所有一对多中的多
        /// </summary>
        /// <returns>一对多中的多集合</returns>
        public IQueryable<YiDuiDuoZhongDeDuo> GetAll(SysEntities db)
        {
            return db.YiDuiDuoZhongDeDuo.AsQueryable();
        }
        /// <summary>
        /// 导出Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        // <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<YiDuiDuoZhongDeDuo> DaoChuData(SysEntities db, FlexigridParam param, params object[] listQuery)
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
                    
                    if (queryDic.ContainsKey("MyCaiGouXuQiouJiHuaId") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "MyCaiGouXuQiouJiHuaId")
                    {//查询一对多关系的列名
                        where += "it.MyCaiGouXuQiouJiHuaId is null";
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
            return db.YiDuiDuoZhongDeDuo
                     .Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it." + param.SortName.GetString() + " " + param.SortOrder.GetString())
                     .AsQueryable();   

        }
        /// <summary>
        /// 通过主键id，获取一对多中的多---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>一对多中的多</returns>
        public YiDuiDuoZhongDeDuo GetById(int id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取一对多中的多---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>一对多中的多</returns>
        public YiDuiDuoZhongDeDuo GetById(SysEntities db, int id)
        { 
            return db.YiDuiDuoZhongDeDuo.SingleOrDefault(s => s.Id == id);
        
        }
        /// <summary>
        /// 创建一个一对多中的多
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要创建的一个一对多中的多</param>
        public void Create(SysEntities db, YiDuiDuoZhongDeDuo entity)
        {
            if (entity != null)
            { 
                db.YiDuiDuoZhongDeDuo.AddObject(entity);
            }             
        }
        /// <summary>
        /// 创建一个一对多中的多
        /// </summary>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        public int Create(YiDuiDuoZhongDeDuo entity)
        {
            using (SysEntities db = new SysEntities())
            {
                Create(db, entity);
                return this.Save(db);
            }
        } 
        /// <summary>
        /// 创建一对多中的多对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Create(SysEntities db, IQueryable<YiDuiDuoZhongDeDuo> entitys)
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
        /// 删除一个一对多中的多
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条一对多中的多的主键</param>
        public void Delete(SysEntities db, int id)
        {
            YiDuiDuoZhongDeDuo deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.YiDuiDuoZhongDeDuo.DeleteObject(deleteItem);
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
            IQueryable<YiDuiDuoZhongDeDuo> collection = from f in db.YiDuiDuoZhongDeDuo
                    where deleteCollection.Contains(f.Id)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.YiDuiDuoZhongDeDuo.DeleteObject(deleteItem);
            }
        }
        /// <summary>
        /// 编辑一个一对多中的多对象
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">将要编辑的一个一对多中的多对象</param>
        public YiDuiDuoZhongDeDuo Edit(SysEntities db, YiDuiDuoZhongDeDuo entity)
        {           
            db.YiDuiDuoZhongDeDuo.Attach(entity);
            db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);         
            return entity;
        }
        /// <summary>
        /// 编辑一对多中的多对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entitys">对象集合</param>
        public void Edit(SysEntities db, IQueryable<YiDuiDuoZhongDeDuo> entitys)
        {
            foreach (YiDuiDuoZhongDeDuo entity in entitys)
            {
                this.Edit(db, entity);
            }
        }

        /// <summary>
        /// 根据MyCaiGouXuQiouJiHuaId，获取所有一对多中的多数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<YiDuiDuoZhongDeDuo> GetByRefMyCaiGouXuQiouJiHuaId(SysEntities db, int id)
        {
            return from c in db.YiDuiDuoZhongDeDuo
                        where c.MyCaiGouXuQiouJiHuaId == id
                        select c;
                      
        }

        public void Dispose()
        {            
        }
    }
}

