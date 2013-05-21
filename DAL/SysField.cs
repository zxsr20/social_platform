using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(SysFieldMetadata))]
    public partial class SysField : IBaseEntity
    {
        
        [Display(Name = "数据字典")]
        public string ParentIdOld { get; set; }
        
        #region 自定义属性

        #endregion

    }
    public class SysFieldMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "名称", Order = 2)]
			public object MyTexts { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "父节点", Order = 3)]
			public object ParentId { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "表名", Order = 4)]
			public object MyTables { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "字段", Order = 5)]
			public object MyColums { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "排序", Order = 6)]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 7)]
			public object Remark { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 8)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 9)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 10)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 11)]
			public object UpdatePerson { get; set; }


    }


}
     
    public class SysFieldSef
    {    
            public string state { get; set; }
            public string _parentId { get; set; }

        			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "名称", Order = 2)]
			public object MyTexts { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "父节点", Order = 3)]
			public object ParentId { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "表名", Order = 4)]
			public object MyTables { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "字段", Order = 5)]
			public object MyColums { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "排序", Order = 6)]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 7)]
			public object Remark { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 8)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 9)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 10)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 11)]
			public object UpdatePerson { get; set; }

}
