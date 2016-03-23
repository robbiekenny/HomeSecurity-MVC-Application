using Microsoft.WindowsAzure.MediaServices.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HomeSecurityVerificationApp.Controllers
{
    [RoutePrefix("Video")]
    public class VideoController : Controller
    {
        [HttpGet]
        [Route("PlayVideo/{video}")]
        public ActionResult PlayVideo(string video)
        {
            var base64EncodedBytes = Convert.FromBase64String(video);
            string vid =  System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            ViewBag.video = vid;
            return View();
        }
    }
}