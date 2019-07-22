using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
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
            // store our ArrayList in a session variable so we can retrieve it later
            var names = HttpContext.Session["Names"] as ArrayList;

            // we want to make sure we create a new ArrayList() if names is null
            if (names == null) names = new ArrayList();
   
            // lowercase the name for better comparison and trim whitepspace
            string lc_name = name.ToLower().Trim();

            // redirect to DuplicateName page if the name already exists in the ArrayList
            if (names.Contains(lc_name))
            {
                // pass the session variable name for when we redirect the user to the DuplicateName page
                // this is just so that we can display the duplicate name entered
                return RedirectToAction("DuplicateName", new { name = name });
            }

            // add the name to the ArrayList
            names.Add(lc_name);

            // store a message to be displayed showing the user that the name was added to the hat
            ViewBag.AddNameMessage = "The Name " + lc_name + " was Added to the Hat!";

            // setting the session variable back to the ArrayList
            HttpContext.Session["Names"] = names;

            return View();
        }


        // Return View for Duplicate Name
        public ActionResult DuplicateName(string name)
        {

            ViewBag.DuplicateNameMessage = "The name " + name + " has already been entered into the hat.  Please enter a different name.";
            return View();
        }


        // Draw a Random Name from the Hat
        public ActionResult DrawName()
        {
            var names = HttpContext.Session["Names"] as ArrayList;

            // if there are no names entered yet - we cannot draw a name
            if (names == null)
            {
                ViewBag.NameDrawnTitle = "No Names Entered";
                ViewBag.NameDrawnMessage = "You must enter a name before you can draw a name.";
                return View();
            }

            // get a random name from the ArrayList
            Random random = new Random();
            int rand_element = random.Next(names.Count);
            string name_drawn = names[rand_element].ToString();
  
            names.RemoveAt(rand_element);

            ViewBag.NameDrawnTitle = "We Have a Winner!";
            ViewBag.NameDrawnMessage = "The Name Drawn was: " + name_drawn;

            return View();
        }
    }
}