using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseShare.Controllers
{
    public class HomeController : Controller
    {
        // Index View
        public ActionResult Index()
        {
            return View("Index");
        }

        // About View
        public ActionResult About()
        {
            ViewBag.Message = "What Does Xpense$hare Do?";

            return View("About");
        }

        // Roadmap View
        public ActionResult RoadMap()
        {
            ViewBag.Message = "Plans for the Future";

            return View("RoadMap");
        }

        // Contact View
        public ActionResult Contact()
        {
            ViewBag.Message = "Let's Chat!";

            return View("Contact");
        }
    }
}