using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ImageController : Controller
    {
        [Route("Image/{format}/{id}.jpg")]
        public ActionResult CreateImage(string format, string id)
        {
            var imgFile = Server.MapPath($@"~\App_Data\covers\{id}.jpg");
            if (!System.IO.File.Exists(imgFile))
            {
                return HttpNotFound();
            }

            var img = new WebImage(imgFile);

            switch (format.ToLower())
            {
                case "medium":
                    img.Resize(300, 3000)
                        .AddTextWatermark("Ingars Movie Database", padding: 7)
                        .AddTextWatermark("Ingars Movie Database", fontColor: "White")
                        .Write("jpg");
                    return new EmptyResult();

                case "small":
                    img.Resize(100, 1000)
                        .Write("jpg");
                    return new EmptyResult();

                default:
                    return new HttpStatusCodeResult(418);
            }
        }
    }
}