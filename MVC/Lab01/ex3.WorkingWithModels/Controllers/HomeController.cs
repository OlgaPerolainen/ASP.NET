using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCR1.Controllers
{
    public class My3Controller : Controller
    {

        public string Index(string name)
        {
            string Greeting = Models.ModelClass.ModelHello() + ", " + name;
            return Greeting;
        }
    }
}