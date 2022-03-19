using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCreditApp.Models;

namespace MvcCreditApp.Controllers
{
    public class HomeController : Controller
    {
        private CreditContext db = new CreditContext();
        public ActionResult Index()
        {
            GiveCredits();
            return View();
        }

        private void GiveCredits()
        {
            var allCredits = db.Credits.ToList<Credit>();
            ViewBag.Credits = allCredits;
        }

        [HttpGet]
        public ActionResult CreateBid()
        {
            GiveCredits();
            var allBids = db.Bids.ToList<Bid>();
            ViewBag.Bids = allBids;
            return View();
        }

        [HttpPost]
        public string CreateBid(Bid newBid)
        {
            newBid.bidDate = DateTime.Now;
            // Добавляем новую заявку в БД
            db.Bids.Add(newBid);
            // Сохраняем в БД все изменения
            db.SaveChanges();
            return "Спасибо, <b>" + newBid.ClientName + "</b>, " +
                "за выбор нашего банка. " +
                "Ваша заявка будет рассмотрена в течение 10 дней.";
 }

        public ActionResult About()
        {
            ViewBag.Message = "Вы можете отправить заявку в любое удобное для вас время";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Наши координаты";

            return View();
        }
    }
}