using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(SysDepartmentMetadata))]
    public partial class SysDepartment : IBaseEntity
    {
        
        [Display(Name = "部门")]
        public string MyParentIdOld { get; set; }
        
        #region 自定义属性

        #endregion

    }
    public class SysDepartmentMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "名称", Order = 2)]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "父部门", Order = 3)]
			public object MyParentId { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "排序", Order = 4)]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.PhoneNumber,ErrorMessage="号码格式不正确")]
			[Display(Name = "电话", Order = 5)]
			public object PhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.PhoneNumber,ErrorMessage="号码格式不正确")]
			[Display(Name = "传真", Order = 6)]
			public object FaxPhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "地址", Order = 7)]
			public object Address { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 8)]
			public object Remark { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 9)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 10)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 11)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 12)]
			public object UpdatePerson { get; set; }


    }


}
     
    public class SysDepartmentSef
    {    
            public string state { get; set; }
            public string _parentId { get; set; }

        			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "名称", Order = 2)]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "父部门", Order = 3)]
			public object MyParentId { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "排序", Order = 4)]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.PhoneNumber,ErrorMessage="号码格式不正确")]
			[Display(Name = "电话", Order = 5)]
			public object PhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.PhoneNumber,ErrorMessage="号码格式不正确")]
			[Display(Name = "传真", Order = 6)]
			public object FaxPhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "地址", Order = 7)]
			public object Address { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 8)]
			public object Remark { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 9)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 10)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 11)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 12)]
			public object UpdatePerson { get; set; }

}
