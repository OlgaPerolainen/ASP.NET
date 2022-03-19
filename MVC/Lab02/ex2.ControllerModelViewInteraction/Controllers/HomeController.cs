using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCR1.Models;

namespace WebMVCR1.Controllers
{
    public class Home2Controller : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = ModelClass.ModelHello();
            ViewData["Message"] = "хорошего настроения!";
            return View();
        }

        [HttpGet]
        public ViewResult InputData()
        {
            return View("~/ex2.ControllerModelViewInteraction/Views/Home2/InputData.cshtml");
        }

        [HttpPost]
        public ViewResult InputData(Person p)
        {
            return View("~/ex2.ControllerModelViewInteraction/Views/Home2/Hello.cshtml", p);
        }
    }
}