using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(shopMetadata))]
    public partial class shop : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class shopMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(60, ErrorMessage = "长度不可超过60")]
			[Display(Name = "名称", Order = 2)]
			public object name { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(5000, ErrorMessage = "长度不可超过5000")]
			[Display(Name = "描述", Order = 3)]
			public object description { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(300, ErrorMessage = "长度不可超过300")]
			[Display(Name = "欢迎图片", Order = 4)]
			public object welcome_pic { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(300, ErrorMessage = "长度不可超过300")]
			[Display(Name = "主页图片", Order = 5)]
			public object home_pic { get; set; }

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
			[Display(Name = "地址", Order = 8)]
			public object address { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(50, ErrorMessage = "长度不可超过50")]
			[Display(Name = "传值", Order = 9)]
			public object fax { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(500, ErrorMessage = "长度不可超过500")]
			[Display(Name = "公交路线", Order = 10)]
			public object bus_way { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "添加时间", Order = 11)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? filltime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(100, ErrorMessage = "长度不可超过100")]
			[Display(Name = "店铺类型", Order = 12)]
			public object shop_type { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "经度", Order = 13)]
			public int? locx { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "纬度", Order = 14)]
			public int? locy { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "用户编码", Order = 15)]
			public object userid { get; set; }


    }


}

