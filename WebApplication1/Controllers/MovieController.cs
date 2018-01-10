using MovieDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MovieController : ImdbControllerBase
    {
        public async Task<ViewResult> Index()
        {
            ViewData.Model = await Db.Movies.ToListAsync();

            return View();
        }

        public async Task<ActionResult> Details(string id)
        {
            var movie = await Db.Movies.FindAsync(id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            ViewData.Model = movie;
            return View();
        }

        public async Task<ViewResult> Genres()
        {
            ViewData.Model = await Db.Genres.ToListAsync();

            return View();
        }

        [Route("Movie/Genre/{genrename}")]
        public async Task<ViewResult> MoviesByGenre(string genrename)
        {
            ViewData.Model = await Db.Movies.Where(m => m.Genre.Name == genrename).ToListAsync();
            ViewBag.Genre = genrename;

            return View("Index");
        }
    }
}