using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using DAL;
using System.Globalization;
namespace App.Models
{
    #region 模型

    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "请填写当前密码")]
        [DataType(DataType.Password)]
        [DisplayName("当前密码")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "请填写新密码")]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayName("新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("确认密码")]
        [Compare("NewPassword", ErrorMessage = "两次密码不一致")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessage = "请填写用户名")]
        [DisplayName("用户名")]
        public string PersonName { get; set; }

        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [Required(ErrorMessage = "请填写密码")]
        [DataType(DataType.Password)]
        [DisplayName("密码")]
        public string Password { get; set; }

        [Required(ErrorMessage = "请填写验证码")]
        [DisplayName("验证码")]
        public string ValidateCode { get; set; }

        [DisplayName("记住我?")]
        public bool RememberMe { get; set; }
    }
    #endregion
    #region 自定义验证密码长度的方法

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute, IClientValidatable
    {
        private const string _defaultErrorMessage = "{0} 至少 {1} 个字符";
        private readonly int _minCharacters = 6;//Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MinRequiredPasswordLength"]);

        public ValidatePasswordLengthAttribute()
            : base(_defaultErrorMessage)
        {
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString,
                name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }



        public System.Collections.Generic.IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[]{
                new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()), _minCharacters, int.MaxValue)
            };
        }
    }
    #endregion
}
