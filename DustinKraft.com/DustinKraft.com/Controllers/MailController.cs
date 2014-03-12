using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Text;

namespace DustinKraft.com.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/
        public ActionResult Index()
        {
            return Content("Gotta post something, yo");
        }


        [HttpPost, AllowCrossSiteJson]
        public ActionResult Index(FormCollection values)
        {
            try
            {
                var m = new MailMessage(values["fromEmail"], values["toEmail"]);
                var sb = new StringBuilder();
                for (var i = 0; i < values.Count; i++)
                {
                    sb.AppendLine(values.Keys[i] + ": " + values[i]);
                }
                m.Body = sb.ToString();
                if (!string.IsNullOrEmpty(values["subject"]))
                {
                    m.Subject = values["subject"];
                }
                else
                {
                    m.Subject = "Test Mail";
                }

                //var client = new SmtpClient("smtp.gmail.com", 587)
                //{
                //    Credentials = new System.Net.NetworkCredential("seedpathsmail@gmail.com", "techIsFun1"),
                //    EnableSsl = true
                //};
                var client = new SmtpClient("mail.dustinkraft.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1")

                };
                client.Send(m);
                return Content("OK");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public ActionResult test()
        {
            try
            {
                var m = new MailMessage("postmaster@dustinkraft.com", "dustin@seedpaths.com");

                m.Subject = "Test Mail";
                m.Body = "testing, 1 2.";
                //var smtp = new SmtpClient("smtp.gmail.com.", 587);
                //smtp.Timeout = 2000;
                //smtp.EnableSsl = true;
                //smtp.Credentials = new System.Net.NetworkCredential("seedpathsmail@gmail.com", "techIsFun1");
                //smtp.Send(m);
                //var client = new SmtpClient("smtp.gmail.com", 587)
                //{
                //    Credentials = new System.Net.NetworkCredential("seedpathsmail@gmail.com", "techIsFun1"),
                //    EnableSsl = true
                //};
                var client = new SmtpClient("mail.dustinkraft.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1")
                    
                };
                client.Send(m);

                return Content("OK");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

    }

    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }
    }
}
