using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QLPhongTro.Common;

namespace QLPhongTro.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (AddSession)Session["USER_SESSION"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}