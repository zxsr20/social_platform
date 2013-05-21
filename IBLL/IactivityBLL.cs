﻿using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using DAL;
using System.ServiceModel;

namespace IBLL
{
    /// <summary>
    /// activity 接口
    /// </summary>
    [ServiceContract(Namespace = "www.langben.com")]
    public interface IactivityBLL
    {
        /// <summary>
        /// 导出Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        /// <param name="id">额外的参数</param>
        /// <returns></returns>
        [OperationContract]
        Common.FlexigridObject FlexigridList(string id, Common.FlexigridParam param);
        /// <summary>
        /// 导出Flexigrid中查询的数据
        /// </summary>
        /// <param name="param">客户端传进的数据</param>
        /// <param name="id">额外的参数</param>
        /// <returns></returns>
        activity[] DaoChu(string id, FlexigridParam param);
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="param">客户端传进的数据</param>
        /// <param name="count">结果集的总数</param>
        /// <returns></returns>
        IQueryable<activity> GetByParam(string id, FlexigridParam param, ref int count);
        /// <summary>
        /// 在查询中输入字符串，自动提示的功能
        /// </summary>
        /// <param name="id">需要查询的数据库字段的名称</param>
        /// <param name="term">输入的字符串</param>
        /// <returns></returns>  
        string SearchAutoComplete(string id, string term);
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        System.Collections.Generic.List<activity> GetAll();
        
        
        /// <summary>
        /// 根据主键，查看详细信息
        /// </summary>
        /// <param name="id">根据主键</param>
        /// <returns></returns>
        [OperationContract]
        activity GetById(int id);    
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        [OperationContract]
         bool Create(ref Common.ValidationErrors validationErrors, DAL.activity entity); 
        /// <summary>
        ///  创建对象集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">对象集合</param>
        /// <returns></returns>
        [OperationContract]
        bool CreateCollection(ref Common.ValidationErrors validationErrors, System.Linq.IQueryable<DAL.activity> entitys);
        /// <summary>
        /// 删除一个对象
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一条数据的主键</param>
        /// <returns></returns>  
        [OperationContract]
        bool Delete(ref Common.ValidationErrors validationErrors, int id);
        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的集合</param>
        /// <returns></returns>       
        [OperationContract]
        bool DeleteCollection(ref Common.ValidationErrors validationErrors, int[] deleteCollection);
        /// <summary>
        /// 编辑一个对象
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        [OperationContract]
        bool Edit(ref Common.ValidationErrors validationErrors, DAL.activity entity); 
        /// <summary>
        ///  创建对象集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">对象集合</param>
        /// <returns></returns>
        [OperationContract]
        bool EditCollection(ref Common.ValidationErrors validationErrors, System.Linq.IQueryable<DAL.activity> entitys);

        [OperationContract]
        bool SaveChange(); 
    }
}

