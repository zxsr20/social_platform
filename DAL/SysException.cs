using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(SysExceptionMetadata))]
    public partial class SysException : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class SysExceptionMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "类型", Order = 2)]
			public object LeiXing { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "内容", Order = 3)]
			public object Message { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "结果", Order = 4)]
			public object Result { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 5)]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "状态", Order = 6)]
			public object State { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 7)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 8)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 9)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 10)]
			public object UpdatePerson { get; set; }


    }


}

