using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {

            ViewBag.uri = Request.Url.ToString().Split(';')[1];
            ViewBag.method = Request.HttpMethod;
            return View();
        }
    }
}