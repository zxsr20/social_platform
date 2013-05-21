using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    [MetadataType(typeof(SysPersonMetadata))]
    public partial class SysPerson : IBaseEntity
    {
        
        [Display(Name = "角色")]
        public string SysRoleId { get; set; }
        [Display(Name = "角色")]
        public string SysRoleIdOld { get; set; }
        
        [Display(Name = "部门")]
        public string SysDepartmentIdOld { get; set; }
        
        #region 自定义属性

        #endregion

    }
    public class SysPersonMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public string Id { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "用户名", Order = 2)]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "姓名", Order = 3)]
			public object MyName { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.Password)]
			[Display(Name = "密码", Order = 4)]
			public object Password { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.Password)]
			[System.Web.Mvc.Compare("Password", ErrorMessage = "两次密码不一致")]
			[Display(Name = "确认密码", Order = 5)]
			public object SurePassword { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.PhoneNumber,ErrorMessage="号码格式不正确")]
			[Display(Name = "手机号码", Order = 6)]
			public object MobilePhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.PhoneNumber,ErrorMessage="号码格式不正确")]
			[Display(Name = "办公电话", Order = 7)]
			public object PhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "省", Order = 8)]
			public object Province { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "市", Order = 9)]
			public object City { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "县", Order = 10)]
			public object Village { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "联系地址", Order = 11)]
			public object Address { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(DataType.EmailAddress,ErrorMessage="邮箱地址格式不正确")]
			[Display(Name = "邮箱", Order = 12)]
			public object EmailAddress { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			[Display(Name = "备注", Order = 13)]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "状态", Order = 14)]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			[Display(Name = "部门", Order = 15)]
			public object SysDepartmentId { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "创建时间", Order = 16)]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "创建人", Order = 17)]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "编辑时间", Order = 18)]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[Display(Name = "编辑人", Order = 19)]
			public object UpdatePerson { get; set; }


    }


}

