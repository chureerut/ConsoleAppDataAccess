using ClassLibrary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppData.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ActionResult Index()
        {
            var test = _uow.Custom.TestConnectWeb("2").ToString();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}