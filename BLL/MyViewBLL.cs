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
    /// 视图模型 接口
    /// </summary>
    public class MyViewBLL : BaseViewBLL
    {
        /// <summary>
        /// 视图模型的数据库访问对象
        /// </summary>
        MyViewRepository repository = null;
        public MyViewBLL()
        {
            repository = new MyViewRepository();
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
            IQueryable<MyView> queryData = GetByParam(id, param, ref count);
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
        public MyView[] DaoChu(string id, FlexigridParam param)
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
        public IQueryable<MyView> GetByParam(string id, FlexigridParam param, ref int count)
        {
            int page = param.Page.GetInt();
            int rp = param.RP.GetInt();
        
                IQueryable<MyView> queryData = repository.DaoChuData(db, param);
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
            using (SysEntities db = new SysEntities())
            {
                var queryData = repository.DaoChuData(db, param);
                if (queryData != null)
                {
                    queryData = queryData.Take(5).Distinct();
                    foreach (var item in queryData)
                    {
                        listString.Add(FlexigridRow.GetPropertyList(item, new string[] { id }).FirstOrDefault());
                    }
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
      
      
        public List<MyView> GetAll()
        {
            SysEntities db = new SysEntities();            
            return repository.GetAll(db).ToList();          
        }   
        /// <summary>
        /// 根据主键获取一个视图模型
        /// </summary>
        /// <param name="id">视图模型的主键</param>
        /// <returns>一个视图模型</returns>
        public MyView GetById(string id)
        {
            SysEntities db = new SysEntities();            
            return repository.GetById(db, id);           
        }
    }
}

