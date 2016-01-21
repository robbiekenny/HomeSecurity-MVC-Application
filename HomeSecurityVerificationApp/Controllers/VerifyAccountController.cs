using System;
using System.Linq;
using System.Web.Mvc;

namespace HomeSecurityVerificationApp.Controllers
{
    public class VerifyAccountController : Controller
    {
        // GET: VerifyAccount
        public ActionResult Index(String email)
        {
            ViewBag.Email = email;
            try
            {
                //https://joaoeduardosousa.wordpress.com/2014/04/23/asp-net-mvc-5-connect-with-azure-sqlserver-database/
                homesecurity_dbEntities context = new homesecurity_dbEntities();
                Account acc = context.Accounts.Where(a => a.Email == email).SingleOrDefault(); //find account with this email

                if (acc != null) //set the verified variable to true
                {
                    acc.Verified = true;
                    context.Entry(acc).CurrentValues.SetValues(acc);
                    context.SaveChanges();
                }
                else
                    return RedirectToAction("Error", "VerifyAccount", new { Email = email});

            }
            catch (Exception e)
            {
                //Response.Write("<script>alert('ERROR " + e.StackTrace + ", " + e.Message + "')</script>"); this is a handy way of debugging
                return RedirectToAction("Error", "VerifyAccount", new { Email = email });
            }
            return View();
        }

        public ActionResult Error(string Email)
        {
            ViewBag.Email = Email;
            return View();
        }
    }
}