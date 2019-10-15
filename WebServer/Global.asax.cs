using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebServer.Controllers;

namespace WebServer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //捕获异常
            GlobalFilters.Filters.Add(new MyExecptionAttribute());
        }
        public class MyExecptionAttribute : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext filterContext)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new BaseController().JR_Get(filterContext.Exception.Message, false);

                //抛出字符串情况
                //filterContext.HttpContext.Response.Write($"发生错误啦：{filterContext.Exception.Message}");
                //filterContext.HttpContext.Response.End();
                base.OnException(filterContext);
            }
        }
    }
}
