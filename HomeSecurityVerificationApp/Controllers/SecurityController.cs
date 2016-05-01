using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeSecurityVerificationApp.Controllers
{
    public class SecurityController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            ViewBag.Email = username;
            return View();
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
