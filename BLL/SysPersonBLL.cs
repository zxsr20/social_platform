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
    /// 人员 
    /// </summary>
    public class SysPersonBLL : BaseBLL, IBLL.ISysPersonBLL
    {
        /// <summary>
        /// 人员的数据库访问对象
        /// </summary>
        SysPersonRepository repository = null;
    
        public SysPersonBLL()
        {
            repository = new SysPersonRepository();
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
            IQueryable<SysPerson> queryData = GetByParam(id, param, ref count);
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
        public SysPerson[] DaoChu(string id, FlexigridParam param)
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
        public IQueryable<SysPerson> GetByParam(string id, FlexigridParam param, ref int count)
        {
            int page = param.Page.GetInt();
            int rp = param.RP.GetInt();
            
            IQueryable<SysPerson> queryData = repository.DaoChuData(db, param);
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
                        if (param.Cols.Contains("SysDepartmentIdOld")&& item.SysDepartmentId != null && item.SysDepartment != null)
                        { 
                                item.SysDepartmentIdOld = item.SysDepartment.Name;//可以做成超链接                            
                        }                  
  
                        if (param.Cols.Contains("Province") && !string.IsNullOrWhiteSpace(item.Province))
                        {
                            item.Province = db.SysField.Where(s => s.Id == item.Province).Select(s => s.MyTexts).FirstOrDefault();
                        }
  
                        if (param.Cols.Contains("City") && !string.IsNullOrWhiteSpace(item.City))
                        {
                            item.City = db.SysField.Where(s => s.Id == item.City).Select(s => s.MyTexts).FirstOrDefault();
                        }
  
                        if (param.Cols.Contains("Village") && !string.IsNullOrWhiteSpace(item.Village))
                        {
                            item.Village = db.SysField.Where(s => s.Id == item.Village).Select(s => s.MyTexts).FirstOrDefault();
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
        /// 创建一个人员
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个人员</param>
        /// <returns></returns>
       public bool Create(ref ValidationErrors validationErrors, SysEntities db, SysPerson entity)
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
        /// 创建一个人员
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个人员</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, SysPerson entity)
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
        ///  创建人员集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">人员集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<SysPerson> entitys)
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
        /// 删除一个人员
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一个人员的主键</param>
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
        /// 删除人员集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的人员</param>
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
        ///  创建人员集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">人员集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<SysPerson> entitys)
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
        /// 编辑一个人员
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据上下文</param>
        /// <param name="entity">一个人员</param>
        /// <returns>是否编辑成功</returns>
       public bool Edit(ref ValidationErrors validationErrors, SysEntities db, SysPerson entity)
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
            SysPerson editEntity = repository.Edit(db, entity);
            
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
                validationErrors.Add("编辑人员出错了");
            }
            return false;
        }
        /// <summary>
        /// 编辑一个人员
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个人员</param>
        /// <returns>是否编辑成功</returns>
        public bool Edit(ref ValidationErrors validationErrors, SysPerson entity)
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
        public List<SysPerson> GetAll()
        {            
            return repository.GetAll(db).ToList();          
        }     
        
        /// <summary>
        /// 根据主键获取一个人员
        /// </summary>
        /// <param name="id">人员的主键</param>
        /// <returns>一个人员</returns>
        public SysPerson GetById(string id)
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
        /// 根据SysDepartmentIdId，获取所有人员数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<SysPerson> GetByRefSysDepartmentId(string id)
        {
            return repository.GetByRefSysDepartmentId(db, id).ToList();                      
        }

    }
}

