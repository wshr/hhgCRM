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


            return JR_Post(App.Bussiness.Service.TestService.Proxy.Test());
        }
    }
}
