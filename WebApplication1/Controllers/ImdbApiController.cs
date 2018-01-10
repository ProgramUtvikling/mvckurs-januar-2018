using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace WebApplication1.Controllers
{
    public class ImdbApiController : ImdbControllerBase
    {
        #region *** TOP SECRET ***
        public ActionResult Movies(string fmt = "xml")
        {
            switch (fmt.ToLower())
            {
                case "xml": return MoviesAsXml();
                case "json": return MoviesAsJson();
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult MoviesAsJson()
        {
            var doc = from movie in Db.Movies
                      select new
                      {
                          id = movie.MovieId,
                          title = movie.Title
                      };

            return Json(doc, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult MoviesAsXml()
        {
            var movies = Db.Movies.ToList();
            var doc = new XElement("movies", from movie in movies
                                             select new XElement("movie",
                                                new XAttribute("id", movie.MovieId),
                                                new XAttribute("title", movie.Title)
                                             )
                                  );
            return Content(doc.ToString(), "application/xml");
        }

        [Route("Movie/Details/{id}.xml")]
        public ActionResult MovieDetails(string id)
        {
            var movie = Db.Movies.Find(id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            var doc = new XElement("movie",
                new XAttribute("id", movie.MovieId),
                new XAttribute("title", movie.Title),
                new XAttribute("originalTitle", movie.OriginalTitle),
                new XAttribute("genre", movie.Genre.Name),
                new XAttribute("description", movie.Description),
                new XAttribute("runLen", movie.RunningLength),
                from person in movie.Actors select new XElement("actor", person.Name),
                from person in movie.Producers select new XElement("producer", person.Name),
                from person in movie.Directors select new XElement("director", person.Name),
                new XCData(movie.Description)
                );

            return Content(doc.ToString(), "application/xml");
        }
    }
}