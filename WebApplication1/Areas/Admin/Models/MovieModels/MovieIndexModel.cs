using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Admin.Models.MovieModels
{
    public class MovieIndexModel
    {
        public string MovieId { get; set; }
        public string Title { get; set; }

        [UIHint("Duration")]
        public int RunningLength { get; set; }
    }
}