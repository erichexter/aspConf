namespace aspConf.Controllers {
    using System.Web.Mvc;

    public class SpeakersController : ConfController {
        public ActionResult Index() {
            var result = Repository.GetActiveSpeakers();
            return View(result);
        }
    }
}
