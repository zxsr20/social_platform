﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using DAL;
using Common;

namespace BLL
{
    /// <summary>
    /// 模块 
    /// </summary>
    public class SysMenuBLL : BaseBLL, IBLL.ISysMenuBLL
    {
        /// <summary>
        /// 模块的数据库访问对象
        /// </summary>
        SysMenuRepository repository = null;
    
        public SysMenuBLL()
        {
            repository = new SysMenuRepository();
        }
        /// <summary>
        /// Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        /// <param name="id">额外的参数</param>
        /// <returns></returns>
        public FlexigridObject FlexigridList(string id, FlexigridParam param)
        {
            int count = 0;
            IQueryable<SysMenu> queryData = GetByParam(id, param, ref count);
            FlexigridObject flexigridObject = new FlexigridObject()
            {
                FlexigridPara = param,
                total = (count > 0) ? count : 0,
                Query = queryData
            };
            return flexigridObject;
        }
        /// <summary>
        /// 导出Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        /// <param name="id">额外的参数</param>
        /// <returns></returns>
        public SysMenu[] DaoChu(string id, FlexigridParam param)
        { 
                return repository.DaoChuData(db, param).ToArray();              
        }
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="param">客户端传进的数据</param>
        /// <param name="count">结果集的总数</param>
        /// <returns></returns>
        public IQueryable<SysMenu> GetByParam(string id, FlexigridParam param, ref int count)
        {
            int page = param.Page.GetInt();
            int rp = param.RP.GetInt();
            
            IQueryable<SysMenu> queryData = repository.DaoChuData(db, param);
            count = queryData.Count();
            if (count > 0)
            {
                if (page <= 1)
                {
                    queryData = queryData.Take(rp);
                }
                else
                { 
                    queryData = queryData.Skip((page - 1) * rp).Take(rp);
                }
                
                    foreach (var item in queryData)
                    {
                        if (param.Cols.Contains("ParentId")&& !string.IsNullOrWhiteSpace(item.ParentId) && item.SysMenu2 != null)
                        { 
                                item.ParentId = item.SysMenu2.Name;//可以做成超链接                            
                        }                    
  
                        if (param.Cols.Contains("State") && !string.IsNullOrWhiteSpace(item.State))
                        {
                            item.State = db.SysField.Where(s => s.Id == item.State).Select(s => s.MyTexts).FirstOrDefault();
                        }
 
                        if (param.Cols.Contains("SysRoleId") && item.SysRole != null)
                        {
                            item.SysRoleId = string.Empty;
                            foreach (var it in item.SysRole)
                            {
                                item.SysRoleId += it.Name + ' ';
                            }                         
                        } 

                    }
 
            }
            return queryData;
        }
        /// <summary>
        /// 在查询中输入字符串，自动提示的功能
        /// </summary>
        /// <param name="id">需要查询的数据库字段的名称</param>
        /// <param name="term">输入的字符串</param>
        /// <returns></returns>  
        public string SearchAutoComplete(string id, string term)
        {
            FlexigridParam param = new FlexigridParam();
            param.Query = id + "&" + term + "^";
            param.SortName = id;

            List<string> listString = new List<string>();
          
            var queryData = repository.DaoChuData(db, param);
            if (queryData != null)
            {
                queryData = queryData.Take(5).Distinct();
                foreach (var item in queryData)
                {
                    listString.Add(FlexigridRow.GetPropertyList(item, new string[] { id }).FirstOrDefault());
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            int i = 0;
            foreach (var item in listString)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                if (i == 0)
                {
                    i++;
                    stringBuilder.Append(@"{@label@:@" + item + "@}");
                }
                else
                {
                    stringBuilder.Append(",");
                    stringBuilder.Append(@"{@label@:@" + item + "@}");
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString().Replace('@', '"') ;
        }
        /// <summary>
        /// 创建一个模块
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个模块</param>
        /// <returns></returns>
       public bool Create(ref ValidationErrors validationErrors, SysEntities db, SysMenu entity)
        {   
            int count = 1;
        
            foreach (var item in entity.SysRoleId.GetIdSort())
            {
                SysRole sys = new SysRole { Id = item };
                db.SysRole.Attach(sys);
                entity.SysRole.Add(sys);
                count++;
            }

            repository.Create(db, entity);
            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("创建出错了");
            }
            return false;
        }
        /// <summary>
        /// 创建一个模块
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个模块</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, SysMenu entity)
        {
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                { 
                    if (Create(ref validationErrors, db, entity))
                    {
                        transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        Transaction.Current.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建模块集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">模块集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<SysMenu> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int flag = 0, count = entitys.Count();
                    if (count > 0)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            foreach (var entity in entitys)
                            {
                                if (Create(ref validationErrors, db, entity))
                                {
                                    flag++;
                                }
                                else
                                {
                                    Transaction.Current.Rollback();
                                    return false;
                                }
                            }
                            if (count == flag)
                            {
                                transactionScope.Complete();
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }

      /// <summary>
        /// 删除一个模块
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一个模块的主键</param>
        /// <returns></returns>  
        public bool Delete(ref ValidationErrors validationErrors, string id)
        {
            try
            {
                return repository.Delete(id) == 1;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        /// 删除模块集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的模块</param>
        /// <returns></returns>    
        public bool DeleteCollection(ref ValidationErrors validationErrors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                { 

                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            repository.Delete(db, deleteCollection);
                            if (deleteCollection.Length == repository.Save(db))
                            {
                                transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                Transaction.Current.Rollback();
                            }
                        }
                    
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建模块集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">模块集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<SysMenu> entitys)
        {
            if (entitys != null)
            {
                try
                {
                    int flag = 0, count = entitys.Count();
                    if (count > 0)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            foreach (var entity in entitys)
                            {
                                if (Edit(ref validationErrors, db, entity))
                                {
                                    flag++;
                                }
                                else
                                {
                                    Transaction.Current.Rollback();
                                    return false;
                                }
                            }
                            if (count == flag)
                            {
                                transactionScope.Complete();
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    validationErrors.Add(ex.Message);
                    ExceptionsHander.WriteExceptions(ex);                
                }
            }
            return false;
        }
        /// <summary>
        /// 编辑一个模块
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据上下文</param>
        /// <param name="entity">一个模块</param>
        /// <returns>是否编辑成功</returns>
       public bool Edit(ref ValidationErrors validationErrors, SysEntities db, SysMenu entity)
        {  /*                       
                           * 不操作 原有 现有
                           * 增加   原没 现有
                           * 删除   原有 现没
                           */
            if (entity == null)
            {
                return false;
            }
            int count = 1;
            SysMenu editEntity = repository.Edit(db, entity);
            
            List<string> addSysRoleId = new List<string>();
            List<string> deleteSysRoleId = new List<string>();
            GetDiffrent(entity.SysRoleId.GetIdSort(), entity.SysRoleIdOld.GetIdSort(), ref addSysRoleId, ref deleteSysRoleId);
            if (addSysRoleId != null && addSysRoleId.Count() > 0)
            {
                foreach (var item in addSysRoleId)
                {
                    SysRole sys = new SysRole { Id = item };
                    db.SysRole.Attach(sys);
                    editEntity.SysRole.Add(sys);
                    count++;
                }
            }
            if (deleteSysRoleId != null && deleteSysRoleId.Count() > 0)
            {
                List<SysRole> listEntity = new List<SysRole>();
                foreach (var item in deleteSysRoleId)
                {
                    SysRole sys = new SysRole { Id = item };
                    listEntity.Add(sys);
                    db.SysRole.Attach(sys);
                }
                foreach (SysRole item in listEntity)
                {
                    editEntity.SysRole.Remove(item);//查询数据库
                    count++;
                }
            } 

            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("编辑模块出错了");
            }
            return false;
        }
        /// <summary>
        /// 编辑一个模块
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个模块</param>
        /// <returns>是否编辑成功</returns>
        public bool Edit(ref ValidationErrors validationErrors, SysMenu entity)
        {           
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                { 
                    if (Edit(ref validationErrors, db, entity))
                    {
                        transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        Transaction.Current.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        public List<SysMenu> GetAll()
        {            
            return repository.GetAll(db).ToList();          
        }     
        
        /// <summary>
        /// 获取自连接树形列表数据
        /// </summary>
        /// <returns>自定义的树形结构</returns>

                   
        public List<SysMenuSef> GetAllMetadata(string id)
        { 
            IQueryable<SysMenu> allMetadata;
            if (id == null)
            {
                allMetadata = db.SysMenu.Where(w => w.ParentId == null).AsQueryable();
            }
            else
            {
                allMetadata = db.SysMenu.Where(w => w.ParentId == id).AsQueryable();
            }
            return allMetadata.Select(s =>
                new SysMenuSef
                {
Id = s.Id
					,Name = s.Name
					,_parentId = s.ParentId
					,state = db.SysMenu.Any(a => a.ParentId == s.Id) ? "closed" : null
					,Url = s.Url
					,Iconic = s.Iconic
					,Sort = s.Sort
					,Remark = s.Remark
					,State = db.SysField.Where(w => w.Id == s.State).Select(m => m.MyTexts).FirstOrDefault()
					,CreatePerson = s.CreatePerson
					,CreateTime = s.CreateTime
					,UpdateTime = s.UpdateTime
					,UpdatePerson = s.UpdatePerson
					
                }).OrderBy(o => o.Id).ToList();
        }
            
        /// <summary>
        /// 根据主键获取一个模块
        /// </summary>
        /// <param name="id">模块的主键</param>
        /// <returns>一个模块</returns>
        public SysMenu GetById(string id)
        {          
            return repository.GetById(db, id);           
        }
        
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<SysRole> GetRefSysRole(string id)
        { 
            return repository.GetRefSysRole(db, id).ToList();
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<SysRole> GetRefSysRole()
        { 
            return repository.GetRefSysRole(db).ToList();
        }

        
        /// <summary>
        /// 根据ParentIdId，获取所有模块数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<SysMenu> GetByRefParentId(string id)
        {
            return repository.GetByRefParentId(db, id).ToList();                      
        }

    }
}

