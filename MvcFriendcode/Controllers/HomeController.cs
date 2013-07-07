using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFriendcode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your window to the world. Or at least the bit that's been coded.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "There's a lot to know.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kinda redundant, don't you think?";

            return View();
        }
    }
}
