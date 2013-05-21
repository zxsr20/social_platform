using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(youhuiMetadata))]
    public partial class youhui : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class youhuiMetadata
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
			public object decription { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "价格", Order = 4)]
			public object net_price { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "节省", Order = 5)]
			public object save_money { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(50, ErrorMessage = "长度不可超过50")]
			[Display(Name = "电话", Order = 6)]
			public object telephone { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(50, ErrorMessage = "长度不可超过50")]
			[Display(Name = "手机", Order = 7)]
			public object mobile { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "用户编码", Order = 8)]
			public object userid { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "更新时间", Order = 9)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? updatetime { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "添加时间", Order = 10)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? addtime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(100, ErrorMessage = "长度不可超过100")]
			[Display(Name = "图片", Order = 11)]
			public object pic { get; set; }


    }


}

