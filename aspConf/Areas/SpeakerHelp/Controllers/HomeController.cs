using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspConf.Areas.SpeakerHelp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /SpeakerHelp/Home/
        public ActionResult UploadRecording()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
