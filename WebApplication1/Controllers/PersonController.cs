using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.PersonModels;

namespace WebApplication1.Controllers
{
    public class PersonController : ImdbControllerBase
    {
        public ViewResult Actors()
        {
            var people = from person in Db.Persons
                         where person.ActedMovies.Any()
                         select person;

            ViewData.Model = new PersonListModel() { Name = "Skuespillere", People = people };
            return View("Index");
        }

        public ViewResult Producers()
        {
            var people = from person in Db.Persons
                         where person.ProducedMovies.Any()
                         select person;
            ViewData.Model = new PersonListModel() { Name = "Produsenter", People = people };

            return View("Index");
        }

        public ViewResult Directors()
        {
            var people = from person in Db.Persons
                         where person.DirectedMovies.Any()
                         select person;
            ViewData.Model = new PersonListModel() { Name = "Regisører", People = people };

            return View("Index");
        }

        [Route(@"Person/{id:int}")]
        public ViewResult Details(int id)
        {
            ViewData.Model = Db.Persons.Find(id);

            return View();
        }
    }
}