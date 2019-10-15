using App.Bussiness.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServer.Entities;

namespace WebServer.Controllers.User
{
    public class UserController : BaseController
    {
        // GET: User

        public JsonResult errl()
        {

            throw new Exception("用户已禁用，请联系管理员！");

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("用户名或密码不能为空！");
            }
            return JR_Post(UserService.Proxy.Login(username, password));
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonResult Register(string username, string password, string phone,string compid)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("用户名或密码不能为空！");
            }
            UserService.Proxy.Register(username, password, phone, compid);
            return JR_Post(username);
        }

        /// <summary>
        /// 修改用户名密码
        /// </summary>
        /// <param name="newpass"></param>
        /// <param name="oldpass"></param>
        /// <returns></returns>
        public JsonResult UpdatePassword(string newpass, string oldpass)
        {
            return JR_Post(UserService.Proxy.UpdateTsUserPassword(Token, newpass, oldpass));
        }


    }
}
