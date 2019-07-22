using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Windows.Forms;

namespace HatDrawing.Controllers
{
    public class HomeController : Controller
    {
        // Home Page
        public ActionResult Index()
        {

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
        public ActionResult AddName(string name)
        {
            // Store the name and arraylist in a session variable
            var names = HttpContext.Session["Names"] as ArrayList;

            if (names == null) names = new ArrayList();
   
            string lc_name = name.ToLower();

            // redirect to DuplicateName page if the name exists in the arraylist
            if (names.Contains(lc_name))
            {
                // pass the session variable name for when we redirect the user to the duplicate name page
                return RedirectToAction("DuplicateName", new { name = name });
            }

            names.Add(lc_name);

            ViewBag.AddNameMessage = "The Name " + name + " was Added to the Hat!";


            HttpContext.Session["Names"] = names;

            return View();
        }


        // Return View for Duplicate Name
        public ActionResult DuplicateName(string name)
        {

            ViewBag.DuplicateNameMessage = "The name " + name + " has already been entered into the hat.  Please try again.";
            return View();
        }


        // Draw a Random Name from the Hat
        public ActionResult DrawName(ArrayList names)
        {
            Random random = new Random();
            int rand_element = random.Next(names.Count);
            string name_drawn = names[rand_element].ToString();
  
            names.RemoveAt(rand_element);

            ViewBag.NameDrawnMessage = "The Name Drawn was: " + name_drawn + "!";

            return View();
        }
    }
}