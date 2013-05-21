using System;
using System.Collections.Generic;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Runtime.DurableInstancing;
using System.Activities.XamlIntegration;

namespace BLL
{
    /// <summary>
    /// 工作流辅助类
    /// </summary>
    public class WFHelp
    {
        /// <summary>
        /// 工作流的数据库连接
        /// </summary>
        private string m_ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        /// <summary>
        /// 根据id加载工作流
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookMarkValue"></param>
        /// <param name="xaml"></param>
        /// <param name="bookmarkName"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string Load(string id, object bookMarkValue, string xaml = "Activity1.xaml", string bookmarkName = "BookmarkName", params object[] ids)
        {
            WorkflowApplication workflowApplication = new WorkflowApplication(ActivityXamlServices.Load(xaml));
            workflowApplication.InstanceStore = GetInstanceStore();
            workflowApplication.PersistableIdle = (waiea) => PersistableIdleAction.Unload;

            workflowApplication.Load(new Guid(id));
            workflowApplication.ResumeBookmark(bookmarkName, bookMarkValue);

            return "ok";
        }
        /// <summary>
        /// 开始新的工作流
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="xaml"></param>
        /// <returns></returns>
        public string Start(IDictionary<string, object> parameters, string xaml = "Activity1.xaml")
        {
            WorkflowApplication workflowApplication = new WorkflowApplication(ActivityXamlServices.Load(xaml), parameters);
            workflowApplication.InstanceStore = GetInstanceStore();
            workflowApplication.PersistableIdle = (waiea) => PersistableIdleAction.Unload;

            workflowApplication.Run();

            return workflowApplication.Id.ToString();
        }
        /// <summary>
        /// 获取工作流持久化的实例
        /// </summary>
        /// <returns></returns>
        private InstanceStore GetInstanceStore()
        {
            InstanceStore instanceStore = new SqlWorkflowInstanceStore(m_ConnectionString);
            InstanceView view = instanceStore.Execute
                (instanceStore.CreateInstanceHandle(),
                new CreateWorkflowOwnerCommand(),
                TimeSpan.FromSeconds(30));
            instanceStore.DefaultInstanceOwner = view.InstanceOwner;
            return instanceStore;
        }

    }
}