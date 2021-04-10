using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5B2.Controllers
{
    public class AResearchController : Controller
    {
        [F1]
        public ActionResult AA()
        {
            return Content("AA") ;
        }
        [F2]
        public ActionResult AR()
        {
            return Content("AR");
        }
        [F3]
        public ActionResult AE()
        {
            throw new Exception("AE");
            return Content("AE");
        }

        public class F1Attribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<h1>F1 after</h1>");
            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<h1>F1 before</h1>");
            }
        }


        public class F2Attribute : FilterAttribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<h1>F2 before</h1>");
            }

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<h1>F2 before</h1>");
            }
        }
        public class F3Attribute : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>F3 error</p>");
                ViewResult vr = new ViewResult();
                vr.ViewName = "Error";
                filterContext.Result = vr;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}