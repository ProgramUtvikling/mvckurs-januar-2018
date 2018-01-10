using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOn(string username, string password, string returnUrl)
        {
            if(username == "arjan" && password == "pass")
            {
                FormsAuthentication.SetAuthCookie(username, false);

                if (string.IsNullOrWhiteSpace(returnUrl))
                {
                    return View("LogOnSucceeded");
                }
                return Redirect(returnUrl);
            }

            return View();
        }
    }
}