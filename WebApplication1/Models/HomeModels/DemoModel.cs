using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.HomeModels
{
    public class DemoModel
    {
        public string Overskrift { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Innhold { get; set; }
    }
}