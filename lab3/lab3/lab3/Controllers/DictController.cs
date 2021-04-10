using lab3.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class DictController : Controller
    {
        BKS_DB bKS_DB = new BKS_DB();
        // GET: Dict
        public ActionResult Index()
        {
           ViewBag.data= bKS_DB.GetAll();
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddSave(string last_name,string phone_number)
        {
            bKS_DB.Add(last_name, phone_number);
            return Redirect("/Dict/index");
        }
        public ActionResult Update(string last_name, string phone_number,int id)
        {
            ViewBag.last_name = last_name;
            ViewBag.phone_number = phone_number;
            ViewBag.id = id;
            return View();
        }
        public ActionResult UpdateSave(string last_name,string phone_number,int id)
        {
            bKS_DB.Update(id, last_name, phone_number);
            return Redirect("/Dict/index");
        }
        public ActionResult Delete(string last_name, string phone_number, int id)
        {
            ViewBag.last_name = last_name;
            ViewBag.phone_number = phone_number;
            ViewBag.id = id;
            return View();
        }
        public ActionResult DeleteSave(int id)
        {
             bKS_DB.Delete(id);
            return Redirect("/Dict/index");
        }
    }
}