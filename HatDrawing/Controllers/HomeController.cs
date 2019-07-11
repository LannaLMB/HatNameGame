using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HatDrawing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A brief description of how the virtual hat game works: ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Lanna Brasure";

            return View();
        }

        public ActionResult AddName(string name)
        {
            ViewBag.Name = name;

            return View();
        }
    }
}