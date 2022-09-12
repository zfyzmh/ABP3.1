
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Runtime.Session;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Abp.Domain.Repositories;
using System.Linq;
using MyProject.Authorization.Users;

namespace MyProject
{
    public class abpHelper
    {
        /// <summary>
        /// 取得当前用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetCurrentUser(long userId)
        {
            UserManager UserManager1 = GetInstance<UserManager>();
            var user = UserManager1.GetUserById(userId);
            return user;

        }

        /// <summary>
        /// 取得当前登录用户的姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetCurrentUserFamilyName(long? userId)
        {
            UserManager UserManager1 = GetInstance<UserManager>();
            var user = UserManager1.GetUserById((long)userId);
            return user.FullName.Replace(" ", "");

        }


        /// <summary>
        /// 取得登录用户名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetCurrentUserName(long? userId)
        {
            UserManager UserManager1 = GetInstance<UserManager>();
            var user = UserManager1.GetUserById((long)userId);
            return user.UserName;
        }
        /// <summary>
        /// 返回用户权限信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IList<Authorization.Roles.Role> GetCurrentUserRoles(long userId)
        {
            UserManager UserManager1 = GetInstance<UserManager>();
            var user = UserManager1.GetUserById(userId);
            var Roles = UserManager1.GetRolesAsync(user);

            Authorization.Roles.RoleManager RoleManager1 = GetInstance<Authorization.Roles.RoleManager>();
            List<Authorization.Roles.Role> result = new List<Authorization.Roles.Role>();
            foreach (string str in Roles.Result)
            {

                result.Add(RoleManager1.GetRoleByName(str));
            }
            return result;

        }
        /// 从IOC中取得类实例
        /// </summary>
        /// <typeparam name="TClass"><peparam>
        /// <returns></returns>
        public static TClass GetInstance<TClass>()
        {
            var UserManager = Abp.Dependency.IocManager.Instance.Resolve<TClass>();

            return UserManager;

        }

        /// <summary>
        /// 返回可执行DBContext
        /// </summary>
        /// <returns></returns>
        public static Public.ISqlExecuterDapper GetDB()
        {

            var UserManager = Abp.Dependency.IocManager.Instance.Resolve<Public.ISqlExecuterDapper>();

            return UserManager;

        }

        /// <summary>
        /// 实体整体转换成另一个实体
        /// </summary>
        /// <typeparam name="T"><peparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Convert<T>(object obj)
        {
            string json = ToJson(obj);

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            return result;
        }

        public static object FromJson(string json)
        {

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            return result;
        }
        /// <summary>
        /// 转化JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return result;
        }
    }
}
