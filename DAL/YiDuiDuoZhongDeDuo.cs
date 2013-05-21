using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(YiDuiDuoZhongDeDuoMetadata))]
    public partial class YiDuiDuoZhongDeDuo : IBaseEntity
    {
        
        [Display(Name = "一对多中的一")]
        public string MyCaiGouXuQiouJiHuaIdOld { get; set; }
        
        #region 自定义属性

        #endregion

    }
    public class YiDuiDuoZhongDeDuoMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "名称", Order = 2)]
			public object MingCheng { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "数量", Order = 3)]
			public int? ShuLiang { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "产品目录", Order = 4)]
			public object ChanPinMuLu { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "规格型号", Order = 5)]
			public object GuiGeXingHao { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "采购计划", Order = 6)]
			public int? MyCaiGouXuQiouJiHuaId { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(8, ErrorMessage = "长度不可超过8")]
			[Display(Name = "计量单位", Order = 7)]
			public object JiLiangDanWei { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.DateTime,ErrorMessage="时间格式不正确")]
			[Display(Name = "交货期限", Order = 8)]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? JiaoHuoQiXian { get; set; }

			[ScaffoldColumn(true)]
			[DataType(DataType.Currency,ErrorMessage="货币格式不正确")]
			[Display(Name = "预算单价(元)", Order = 9)]
			public int? Currency { get; set; }


    }


}

