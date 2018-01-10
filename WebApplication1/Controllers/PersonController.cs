using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.PersonModels;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        private readonly ImdbContext _db;

        public PersonController()
        {
            _db = new ImdbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();

            base.Dispose(disposing);
        }

        public ViewResult Actors()
        {
            var people = from person in _db.Persons
                         where person.ActedMovies.Any()
                         select person;

            ViewData.Model = new PersonListModel() { Name = "Skuespillere", People = people };
            return View("Index");
        }

        public ViewResult Producers()
        {
            var people = from person in _db.Persons
                         where person.ProducedMovies.Any()
                         select person;
            ViewData.Model = new PersonListModel() { Name = "Produsenter", People = people };

            return View("Index");
        }

        public ViewResult Directors()
        {
            var people = from person in _db.Persons
                         where person.DirectedMovies.Any()
                         select person;
            ViewData.Model = new PersonListModel() { Name = "Regisører", People = people };

            return View("Index");
        }

        [Route(@"Person/{id:int}")]
        public ViewResult Details(int id)
        {
            ViewData.Model = _db.Persons.Find(id);

            return View();
        }
    }
}