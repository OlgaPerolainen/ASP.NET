using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCR1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = Models.ModelClass.ModelHello();
            ViewData["Message"] = "хорошего настроения";
            return View("~/ex1.ControllerViewInteraction/Views/Home/Index.cshtml");
        }
    }
}