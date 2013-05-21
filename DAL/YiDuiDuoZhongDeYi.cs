using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(YiDuiDuoZhongDeYiMetadata))]
    public partial class YiDuiDuoZhongDeYi : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class YiDuiDuoZhongDeYiMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "名称", Order = 2)]
			public object MingCheng { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "任务属性", Order = 3)]
			public object RenWuShuXing { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "采购类型", Order = 4)]
			public object CaiGouLeiXing { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 5)]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "状态", Order = 6)]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(2000, ErrorMessage = "长度不可超过2000")]
			[Display(Name = "招标管理", Order = 7)]
			public object ZhaoBiaoGuanLiId { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(2000, ErrorMessage = "长度不可超过2000")]
			[Display(Name = "供应商", Order = 8)]
			public object GongYingShangId { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(2000, ErrorMessage = "长度不可超过2000")]
			[Display(Name = "采购方案", Order = 9)]
			public object CaiGouFangAnId { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "审批人", Order = 10)]
			public object SysPersonId { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 11)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 12)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "服务器", Order = 13)]
			public object ServiceId { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 14)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 15)]
			public object UpdatePerson { get; set; }


    }


}

