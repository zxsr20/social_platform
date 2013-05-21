using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using DAL;
using Common;

namespace BLL
{
    /// <summary>
    /// 角色 
    /// </summary>
    public class SysRoleBLL : BaseBLL, IBLL.ISysRoleBLL
    {
        /// <summary>
        /// 角色的数据库访问对象
        /// </summary>
        SysRoleRepository repository = null;
    
        public SysRoleBLL()
        {
            repository = new SysRoleRepository();
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
            IQueryable<SysRole> queryData = GetByParam(id, param, ref count);
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
        public SysRole[] DaoChu(string id, FlexigridParam param)
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
        public IQueryable<SysRole> GetByParam(string id, FlexigridParam param, ref int count)
        {
            int page = param.Page.GetInt();
            int rp = param.RP.GetInt();
            
            if (!string.IsNullOrWhiteSpace(id))
            {
                param.Query += "SysMenu&" + id + "^";
            }
            
            IQueryable<SysRole> queryData = repository.DaoChuData(db, param);
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
                        if (param.Cols.Contains("SysPersonId") && item.SysPerson != null)
                        {
                            item.SysPersonId = string.Empty;
                            foreach (var it in item.SysPerson)
                            {
                                item.SysPersonId += it.Name + ' ';
                            }                         
                        } 
 
                        if (param.Cols.Contains("SysMenuId") && item.SysMenu != null)
                        {
                            item.SysMenuId = string.Empty;
                            foreach (var it in item.SysMenu)
                            {
                                item.SysMenuId += it.Name + ' ';
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
        /// 创建一个角色
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个角色</param>
        /// <returns></returns>
       public bool Create(ref ValidationErrors validationErrors, SysEntities db, SysRole entity)
        {   
            int count = 1;
        
            foreach (var item in entity.SysPersonId.GetIdSort())
            {
                SysPerson sys = new SysPerson { Id = item };
                db.SysPerson.Attach(sys);
                entity.SysPerson.Add(sys);
                count++;
            }

            foreach (var item in entity.SysMenuId.GetIdSort())
            {
                SysMenu sys = new SysMenu { Id = item };
                db.SysMenu.Attach(sys);
                entity.SysMenu.Add(sys);
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
        /// 创建一个角色
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个角色</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, SysRole entity)
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
        ///  创建角色集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">角色集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<SysRole> entitys)
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
        /// 删除一个角色
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一个角色的主键</param>
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
        /// 删除角色集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的角色</param>
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
        ///  创建角色集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">角色集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<SysRole> entitys)
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
        /// 编辑一个角色
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据上下文</param>
        /// <param name="entity">一个角色</param>
        /// <returns>是否编辑成功</returns>
       public bool Edit(ref ValidationErrors validationErrors, SysEntities db, SysRole entity)
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
            SysRole editEntity = repository.Edit(db, entity);
            
            List<string> addSysPersonId = new List<string>();
            List<string> deleteSysPersonId = new List<string>();
            GetDiffrent(entity.SysPersonId.GetIdSort(), entity.SysPersonIdOld.GetIdSort(), ref addSysPersonId, ref deleteSysPersonId);
            if (addSysPersonId != null && addSysPersonId.Count() > 0)
            {
                foreach (var item in addSysPersonId)
                {
                    SysPerson sys = new SysPerson { Id = item };
                    db.SysPerson.Attach(sys);
                    editEntity.SysPerson.Add(sys);
                    count++;
                }
            }
            if (deleteSysPersonId != null && deleteSysPersonId.Count() > 0)
            {
                List<SysPerson> listEntity = new List<SysPerson>();
                foreach (var item in deleteSysPersonId)
                {
                    SysPerson sys = new SysPerson { Id = item };
                    listEntity.Add(sys);
                    db.SysPerson.Attach(sys);
                }
                foreach (SysPerson item in listEntity)
                {
                    editEntity.SysPerson.Remove(item);//查询数据库
                    count++;
                }
            } 

            List<string> addSysMenuId = new List<string>();
            List<string> deleteSysMenuId = new List<string>();
            GetDiffrent(entity.SysMenuId.GetIdSort(), entity.SysMenuIdOld.GetIdSort(), ref addSysMenuId, ref deleteSysMenuId);
            if (addSysMenuId != null && addSysMenuId.Count() > 0)
            {
                foreach (var item in addSysMenuId)
                {
                    SysMenu sys = new SysMenu { Id = item };
                    db.SysMenu.Attach(sys);
                    editEntity.SysMenu.Add(sys);
                    count++;
                }
            }
            if (deleteSysMenuId != null && deleteSysMenuId.Count() > 0)
            {
                List<SysMenu> listEntity = new List<SysMenu>();
                foreach (var item in deleteSysMenuId)
                {
                    SysMenu sys = new SysMenu { Id = item };
                    listEntity.Add(sys);
                    db.SysMenu.Attach(sys);
                }
                foreach (SysMenu item in listEntity)
                {
                    editEntity.SysMenu.Remove(item);//查询数据库
                    count++;
                }
            } 

            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("编辑角色出错了");
            }
            return false;
        }
        /// <summary>
        /// 编辑一个角色
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个角色</param>
        /// <returns>是否编辑成功</returns>
        public bool Edit(ref ValidationErrors validationErrors, SysRole entity)
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
        public List<SysRole> GetAll()
        {            
            return repository.GetAll(db).ToList();          
        }     
        
        /// <summary>
        /// 根据主键获取一个角色
        /// </summary>
        /// <param name="id">角色的主键</param>
        /// <returns>一个角色</returns>
        public SysRole GetById(string id)
        {          
            return repository.GetById(db, id);           
        }
        
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<SysPerson> GetRefSysPerson(string id)
        { 
            return repository.GetRefSysPerson(db, id).ToList();
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<SysPerson> GetRefSysPerson()
        { 
            return repository.GetRefSysPerson(db).ToList();
        }

		/// <summary>
        /// 设置一个模块
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个模块</param>
        /// <returns>是否设置成功</returns>
        public bool SetSysMenu(ref ValidationErrors validationErrors, SysRole entity)
        {
            bool bResult = false;

            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    SysRole editEntity = repository.GetById(db, entity.Id);
                    editEntity.SysMenu.Clear();//全部删除
                    List<string> newId = MergeChildren(entity.SysMenuId.ToList());
                    var listEntity = from m in db.SysMenu where newId.Any(d => d == m.Id) select m;
                    foreach (SysMenu item in listEntity)
                    {
                        editEntity.SysMenu.Add(item);//重新添加                           
                    }                
                    int result = repository.Save(db);
                    transactionScope.Complete();
                    bResult = true;
                }
                catch (Exception ex)
                {
                    Transaction.Current.Rollback();                    
                    ExceptionsHander.WriteExceptions(ex);
                    validationErrors.Add("编辑角色出错了。原因"+ex.Message);
                }
            }
            
            return bResult;
        }

        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<SysMenu> GetRefSysMenu(string id)
        { 
            return repository.GetRefSysMenu(db, id).ToList();
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<SysMenu> GetRefSysMenu()
        { 
            return repository.GetRefSysMenu(db).ToList();
        }

        
    }
}

