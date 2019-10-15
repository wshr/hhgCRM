using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServer.Entities;

namespace WebServer.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Default
        public JsonResult Index(string pas)
        {
            string p = pas;
            return Json(App.Bussiness.Service.TestService.Proxy.Test(), JsonRequestBehavior.DenyGet);
        }

        public JsonResult login()
        {
         
            throw new Exception("用户已禁用，请联系管理员！");

        }

        public JsonResult getToken()
        {
            ApiResult ret = new ApiResult();
            ret.Result =Token;
            return Json(ret, JsonRequestBehavior.DenyGet);
        }
    }
}