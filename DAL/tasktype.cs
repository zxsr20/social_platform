using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(tasktypeMetadata))]
    public partial class tasktype : IBaseEntity
    {
        
        [Display(Name = "人员")]
        public string useridOld { get; set; }
        
        #region 自定义属性

        #endregion

    }
    public class tasktypeMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string ID { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(100, ErrorMessage = "长度不可超过100")]
			[Display(Name = "任务类型名称", Order = 2)]
			public object tasktypename { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "用户id", Order = 3)]
			public object userid { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "添加时间", Order = 4)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? addtime { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "是否删除", Order = 5)]
			public int? isdel { get; set; }


    }


}

