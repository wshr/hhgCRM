
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebServer.Entities;

namespace WebServer.Controllers
{
    public class BaseController : Controller
    {
        protected string Token => Request.Headers.GetValues("Authorization")?.FirstOrDefault();

        /// <summary>
        /// 不允许get
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public JsonResult JR_Post(object obj, bool success = true)
        {
            ApiResult ret = new ApiResult
            {
                Success = success,
                Result = obj
            };
            return Json(ret, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 允许get
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public JsonResult JR_Get(object obj, bool success = true)
        {
            ApiResult ret = new ApiResult
            {
                Success = success,
                Result = obj
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}
