using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(dailyMetadata))]
    public partial class daily : IBaseEntity
    {
        
        [Display(Name = "人员")]
        public string useridOld { get; set; }
        
        [Display(Name = "tasktype")]
        public string tasktypeOld { get; set; }
        
        [Display(Name = "status")]
        public string statusOld { get; set; }
        
        #region 自定义属性

        #endregion

    }
    public class dailyMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(100, ErrorMessage = "长度不可超过100")]
			[Display(Name = "标题", Order = 2)]
			public object title { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(1000, ErrorMessage = "长度不可超过1000")]
			[Display(Name = "内容", Order = 3)]
			public object content { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "任务类型", Order = 4)]
			public object tasktype { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "标签", Order = 5)]
			public object tag { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "状态", Order = 6)]
			public object status { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "完成比率", Order = 7)]
			public int? percent { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "开始时间", Order = 8)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? starttime { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "结束时间", Order = 9)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? endtime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "用户id", Order = 10)]
			public object userid { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "添加时间", Order = 11)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? addtime { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "修改时间", Order = 12)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? updatetime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(500, ErrorMessage = "长度不可超过500")]
			[Display(Name = "文件链接", Order = 13)]
			public object filelink { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(1000, ErrorMessage = "长度不可超过1000")]
			[Display(Name = "备注", Order = 14)]
			public object remark { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "是否删除", Order = 15)]
			public int? isdel { get; set; }


    }


}

