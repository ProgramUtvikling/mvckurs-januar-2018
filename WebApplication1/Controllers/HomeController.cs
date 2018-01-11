using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.HomeModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Demo()
        {
            // vis frem skjema
            return View();
        }

        [HttpPost]
        public ViewResult Demo(DemoModel model)
        {
            model.Innhold = Sanitizer.GetSafeHtmlFragment(model.Innhold);

            ViewData.Model = model;
            return View("DemoResult");
        }
    }
}