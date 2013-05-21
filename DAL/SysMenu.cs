using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(SysMenuMetadata))]
    public partial class SysMenu : IBaseEntity
    {
        
        [Display(Name = "角色")]
        public string SysRoleId { get; set; }
        [Display(Name = "角色")]
        public string SysRoleIdOld { get; set; }
        
        [Display(Name = "模块")]
        public string ParentIdOld { get; set; }
        
        #region 自定义属性

        #endregion

    }
    public class SysMenuMetadata
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
			[Display(Name = "父模块", Order = 3)]
			public object ParentId { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.Url,ErrorMessage="网址格式不正确")]
			[Display(Name = "网址", Order = 4)]
			public object Url { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "图标", Order = 5)]
			public object Iconic { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "排序", Order = 6)]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 7)]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "状态", Order = 8)]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 9)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 10)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 11)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 12)]
			public object UpdatePerson { get; set; }


    }


}
     
    public class SysMenuSef
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
			[Display(Name = "父模块", Order = 3)]
			public object ParentId { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.Url,ErrorMessage="网址格式不正确")]
			[Display(Name = "网址", Order = 4)]
			public object Url { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "图标", Order = 5)]
			public object Iconic { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "排序", Order = 6)]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 7)]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "状态", Order = 8)]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 9)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 10)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 11)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 12)]
			public object UpdatePerson { get; set; }

}
