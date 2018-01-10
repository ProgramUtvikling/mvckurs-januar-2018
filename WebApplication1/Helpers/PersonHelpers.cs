using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApplication1.Helpers
{
    public static class PersonHelpers
    {
        public static IHtmlString PrettyJoin(this HtmlHelper html, IEnumerable<Person> people)
        {
            Func<Person, string> makeLink = person => html.ActionLink(person.Name, "Details", "Person", new { id = person.PersonId}, null).ToHtmlString();


            int count = 0;
            string res = "";
            foreach (var person in people.Reverse())
            {
                switch (count++)
                {
                    case 0:
                        res = makeLink(person);
                        break;

                    case 1:
                        res = makeLink(person) + " og " + res;
                        break;

                    default:
                        res = makeLink(person) + ", " + res;
                        break;
                }
            }
            return MvcHtmlString.Create(res);
        }
    }
}