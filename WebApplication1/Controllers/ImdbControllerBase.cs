using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public abstract class ImdbControllerBase : Controller
    {
        protected readonly ImdbContext Db;

        public ImdbControllerBase()
        {
            Db = new ImdbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();

            base.Dispose(disposing);
        }
    }
}