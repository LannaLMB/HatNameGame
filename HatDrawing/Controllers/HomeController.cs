using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HatDrawing.Controllers
{
    public class HomeController : Controller
    {
        // Home Page
        public ActionResult Index()
        {
            // Declare ArrayList and Variables
            ArrayList Names = new ArrayList();
            string lc_name = name.ToLower();

            // if the name has already been entered, we will tell the user that.
            if (Names.Contains(lc_name))
            {
                return RedirectToAction("/Home/DuplicateName");
            }

            // if the name has not been entered, we will add the name to the list.
            Names.Add(lc_name);

            return View();
        }


        // Informational Page
        public ActionResult About()
        {
            ViewBag.Message = "A brief description of how the virtual hat game works: ";

            return View();
        }


        // Contact Information
        public ActionResult Contact()
        {
            ViewBag.Message = "Lanna Brasure";

            return View();
        }


        //  Return View for Name Added
        public ActionResult AddName(string lc_name)
        {
            ViewBag.Name = lc_name;

            return View();
        }


        // Draw a Random Name from the Hat
        public ActionResult DrawName(ArrayList Names)
        {
            Random random = new Random();
            int rand_element = random.Next(Names.Count);
            string name_drawn = Names[rand_element].ToString();
  
            Names.RemoveAt(rand_element);

            ViewBag.NameDrawn = name_drawn;
            return RedirectToAction("/Home/NameDrawn");
        }


        // Return View for Duplicate Name
        public ActionResult DuplicateName(string lc_name)
        {
            ViewBag.DuplicateName = lc_name;

            return View();
        }


        // Return View for Name Drawn
        public ActionResult NameDrawn(string lc_name)
        {
            ViewBag.NameDrawn = lc_name;

            return View();
        }
    }
}