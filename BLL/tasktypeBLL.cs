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
    /// tasktype 
    /// </summary>
    public class tasktypeBLL : BaseBLL, IBLL.ItasktypeBLL
    {
        /// <summary>
        /// tasktype的数据库访问对象
        /// </summary>
        tasktypeRepository repository = null;
        public tasktypeBLL()
        {
            repository = new tasktypeRepository();
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
            IQueryable<tasktype> queryData = GetByParam(id, param, ref count);
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
        public tasktype[] DaoChu(string id, FlexigridParam param)
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
        public IQueryable<tasktype> GetByParam(string id, FlexigridParam param, ref int count)
        {
            int page = param.Page.GetInt();
            int rp = param.RP.GetInt();

            IQueryable<tasktype> queryData = repository.DaoChuData(db, param);
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
                        if (param.Cols.Contains("useridOld")&& item.userid != null && item.SysPerson != null)
                        { 
                                item.useridOld = item.SysPerson.Name;//可以做成超链接                            
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
        /// 创建一个tasktype
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个tasktype</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, tasktype entity)
        {
            try
            {
                return repository.Create(entity) == 1;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建tasktype集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">tasktype集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<tasktype> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int count = entitys.Count();
                    if (count == 1)
                    {
                        return this.Create(ref validationErrors, entitys.FirstOrDefault());
                    }
                    else if (count > 1)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        { 
                            repository.Create(db, entitys);
                            if (count == repository.Save(db))
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
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        /// 删除一个tasktype
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一tasktype的主键</param>
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
        /// 删除tasktype集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">tasktype的集合</param>
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
        ///  创建tasktype集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">tasktype集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<tasktype> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int count = entitys.Count();
                    if (count == 1)
                    {
                        return this.Edit(ref validationErrors, entitys.FirstOrDefault());
                    }
                    else if (count > 1)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        { 
                            repository.Edit(db, entitys);
                            if (count == repository.Save(db))
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
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
         /// <summary>
        /// 编辑一个tasktype
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个tasktype</param>
        /// <returns></returns>
        public bool Edit(ref ValidationErrors validationErrors, tasktype entity)
        {
            try
            { 
                repository.Edit(db, entity);
                return repository.Save(db) == 1;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
      
        public List<tasktype> GetAll()
        {           
            return repository.GetAll(db).ToList();          
        }   
        
        /// <summary>
        /// 根据主键获取一个tasktype
        /// </summary>
        /// <param name="id">tasktype的主键</param>
        /// <returns>一个tasktype</returns>
        public tasktype GetById(string id)
        {           
            return repository.GetById(db, id);           
        }


        /// <summary>
        /// 根据useridId，获取所有tasktype数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<tasktype> GetByRefuserid(string id)
        {
            return repository.GetByRefuserid(db, id).ToList();                      
        }

    }
}

