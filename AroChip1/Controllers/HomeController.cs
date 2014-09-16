using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AroChip1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order()
        {
            AroChip1.Models.AroChipOrder order = new Models.AroChipOrder();
            return View(order);
        }

        public ActionResult Items()
        {
            return View(AroChip1.Models.Item.GetAroStoreItems());
        }

        public ActionResult Payment(int total)
        {
            return View(new AroChip1.Models.PaymentOptions(total));
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}