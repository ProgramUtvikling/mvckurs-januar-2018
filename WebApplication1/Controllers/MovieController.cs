using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly ImdbContext _db;

        public MovieController()
        {
            _db = new ImdbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();

            base.Dispose(disposing);
        }

        public ViewResult Index()
        {
            ViewData.Model = _db.Movies;

            return View();
        }

        public ActionResult Details(string id)
        {
            var movie = _db.Movies.Find(id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            ViewData.Model = movie;
            return View();
        }

        public ViewResult Genres()
        {
            ViewData.Model = _db.Genres;

            return View();
        }

        [Route("Movie/Genre/{genrename}")]
        public ViewResult MoviesByGenre(string genrename)
        {
            ViewData.Model = _db.Movies.Where(m => m.Genre.Name == genrename);
            ViewBag.Genre = genrename;

            return View("Index");
        }
    }
}