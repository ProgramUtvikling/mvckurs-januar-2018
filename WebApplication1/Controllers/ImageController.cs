using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public string CreateImage(string format, string id)
        {
            return $"ImageController.CreateImage({format}, {id})";
        }
    }
}