using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(SysRoleMetadata))]
    public partial class SysRole : IBaseEntity
    {
        
        [Display(Name = "人员")]
        public string SysPersonId { get; set; }
        [Display(Name = "人员")]
        public string SysPersonIdOld { get; set; }
        
        [Display(Name = "模块")]
        public string SysMenuId { get; set; }
        [Display(Name = "模块")]
        public string SysMenuIdOld { get; set; }
        
        #region 自定义属性

        #endregion

    }
    public class SysRoleMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "名称", Order = 2)]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "描述", Order = 3)]
			public object Description { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 4)]
			public object Remark { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 5)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 6)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 7)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 8)]
			public object UpdatePerson { get; set; }


    }


}

