using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.PersonModels
{
    public class PersonListModel
    {
        public string Name { get; set; }
        public IEnumerable<MovieDAL.Person> People { get; set; }
    }
}