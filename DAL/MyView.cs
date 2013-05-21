using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(MyViewMetadata))]
    public partial class MyView : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class MyViewMetadata
    {
			[ScaffoldColumn(true)]
			[Display(Name = "部门id", Order = 1)]
			public object Expr1 { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(233, ErrorMessage = "长度不可超过233")]
			[Display(Name = "名称", Order = 2)]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			[Display(Name = "排序", Order = 3)]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "用户名", Order = 4)]
			public object Expr2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "用户id", Order = 5)]
			public object Id { get; set; }


    }


}

