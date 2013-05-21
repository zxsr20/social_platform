using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class AccountBLL : BaseBLL
    {
        /// <summary>
        /// 验证用户名和密码是否正确
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>是否登录成功</returns>
        public static string ValidateUser(string userName, string password)
        {
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password))
                return null;

            //验证用户信息 
            return AccountRepository.ValidatePerson(userName, password);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="personName">用户名</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>修改密码是否成功</returns>
        public static bool ChangePassword(string personName, string oldPassword, string newPassword)
        {
            if (!string.IsNullOrWhiteSpace(personName) && !string.IsNullOrWhiteSpace(oldPassword) && !string.IsNullOrWhiteSpace(newPassword))
            {
                try
                {
                    if (AccountRepository.ChangePassword(personName, oldPassword, newPassword))
                        return true;
                }
                catch (Exception ex)
                {
                    ExceptionsHander.WriteExceptions(ex);
                }

            }
            return false;
        }
    }
}
