using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DustinKraft.com.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dev() 
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Inst()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Gent()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Dustin()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Contact()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Contact(FormCollection values)
        {
            if (values["check"] != null && values["check"].ToLower().Trim() == "blue")
            {
                var m = new MailMessage("dustin@dustinkraft.com", "kraftdr@gmail.com");
                var sb = new StringBuilder();
                for (var i = 0; i < values.Count; i++)
                {
                    sb.AppendLine(values.Keys[i] + ": " + values[i]);
                }
                m.Body = sb.ToString();
                m.Subject = "Contact from DustinKraft.com";
                

                var client = new SmtpClient("mail.dustinkraft.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1")

                };
                client.Send(m);
                return Content("<h3 class='success'>Awesome. I'll talk to you soon.</h3>");
            }
            else
            {
                //ROBOTS
                ViewBag.Robots = values["check"];
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
        }

    }
}
