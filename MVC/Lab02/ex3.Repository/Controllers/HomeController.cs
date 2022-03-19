using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCR1.Models;

namespace WebMVCR1.Controllers
{
    public class Home3Controller : Controller
    {
        private static PersonRepository personRepository = new PersonRepository();
        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = ModelClass.ModelHello();
            ViewData["Message"] = "хорошего настроения!";
            return View("~/ex3.Repository/Views/Home3/Index.cshtml");
        }

        [HttpGet]
        public ViewResult InputData()
        {
            return View();
        }

        [HttpPost]
        public ViewResult InputData(Person person)
        {
            personRepository.AddResponse(person);
            return View("Hello", person);
        }

        public ViewResult OutputData()
        {
            ViewBag.People = personRepository.GetAllResponses;
            ViewBag.Count = personRepository.NumberOfPersons;
            return View("~/ex3.Repository/Views/Home3/ListOfPersons.cshtml");
        }
    }
}