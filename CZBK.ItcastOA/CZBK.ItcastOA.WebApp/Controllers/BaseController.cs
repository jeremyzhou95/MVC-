using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        /// <summary>
        /// 执行控制器中的方法之前先执行该方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["userInfo"] == null)
            {
                filterContext.Result = Redirect("/login/Index");
                return;
            }
        }
    }
}