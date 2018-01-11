using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.AccountModels;

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
        [ValidateAntiForgeryToken]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "arjan" && model.Password == "pass")
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError("", "Ugylding brukernavn/passord");
            }

            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult LoginStatus()
        {
            if (Request.IsAuthenticated)
            {
                ViewData.Model = User.Identity.Name;
                return PartialView("IsLoggedIn");
            }

            return PartialView("IsNotLoggedIn");
        }
    }
}