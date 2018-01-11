using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Admin.Models.MovieModels
{
    public class MovieDeleteModel
    {
        public string MovieId { get; internal set; }
        public string Title { get; internal set; }
        public string ProductionYear { get; internal set; }
    }
}