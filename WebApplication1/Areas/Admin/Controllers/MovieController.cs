using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Admin.Models.MovieModels;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class MovieController : ImdbControllerBase
    {
        public ActionResult Index()
        {
            ViewData.Model = Db.Movies.Select(m => new MovieIndexModel
            {
                MovieId = m.MovieId,
                Title = m.Title,
                RunningLength = m.RunningLength
            });
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Genres = new SelectList(Db.Genres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MovieCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = new MovieDAL.Movie
                {
                    MovieId = model.MovieId,
                    Title = model.Title,
                    OriginalTitle = model.OriginalTitle,
                    Description = model.Description,
                    ProductionYear = model.ProductionYear,
                    RunningLength = model.RunningLength_Hours * 60 + model.RunningLength_Minutes,
                    Genre = await Db.Genres.FindAsync(model.GenreId)
                };

                Db.Movies.Add(movie);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return Create();
        }

        public static ValidationResult CheckIdLocal(string movieId)
        {
            using (var db = new MovieDAL.ImdbContext())
            {
                if (db.Movies.Any(m => m.MovieId == movieId))
                {
                    return new ValidationResult("Filmen er allerede registrert! (local)");
                }

                return ValidationResult.Success;
            }
        }

        public ActionResult CheckIdRemote(string movieId)
        {
            if (Db.Movies.Any(m => m.MovieId == movieId))
            {
                return Json("Filmen er allerede registrert! (remote)");
            }

            return Json(true);
        }

        public ActionResult Delete(string id)
        {
            var movie = Db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            ViewData.Model = new MovieDeleteModel() { MovieId = movie.MovieId, Title = movie.Title, ProductionYear = movie.ProductionYear };
            return View();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(string id)
        {
            var movie = Db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            Db.Movies.Remove(movie);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}