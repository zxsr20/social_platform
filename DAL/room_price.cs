using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(room_priceMetadata))]
    public partial class room_price : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class room_priceMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 2)]
			public object name { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(3000, ErrorMessage = "长度不可超过3000")]
			[Display(Name = "描述", Order = 3)]
			public object description { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "用户编码", Order = 4)]
			public object userid { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(300, ErrorMessage = "长度不可超过300")]
			[Display(Name = "图片", Order = 5)]
			public object pic { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "添加时间", Order = 6)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? filltime { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "排序号", Order = 7)]
			public int? order { get; set; }


    }


}

