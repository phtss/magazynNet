using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace magazyn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult Magazyny()
        {
            return View();

        }

        public ActionResult Zamówienia()
        {
            return View();
        }

        public ActionResult Pracownicy()
        {
            return View();
        }
    }
}