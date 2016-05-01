using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HomeSecurityVerificationApp.Models;
using System.Web.Security;

namespace HomeSecurityVerificationApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {          
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            homesecurity_dbEntities context = new homesecurity_dbEntities();
            Account acc = context.Accounts.Where(a => a.Email == model.Email).SingleOrDefault();

            if (acc != null)
            {
                byte[] incoming = CustomLoginProviderUtils
                    .hash(model.Password, acc.Salt);

                if (CustomLoginProviderUtils.slowEquals(incoming, acc.SaltedAndHashedPassword)) //passwords match
                {
                    if (acc.Verified)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToAction("Index", "Security");
                    }
                    else
                        ModelState.AddModelError("", "Please validate your email");
                }
                else
                    ModelState.AddModelError("", "Invalid email and password combination");
            }
            //account is null which means the email doesnt exist
            else
                ModelState.AddModelError("", "Invalid email and password combination");

            return View(model);

        }
    }
}