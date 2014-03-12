using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DustinKraft.com.Controllers
{
    public class FitFinanceController : Controller
    {
        //
        // GET: /FitFinance/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View("Index");
        }

    }
}
