namespace aspConf.Controllers {
    using System.Linq;
    using System.Web.Mvc;

    public class SpeakersController : ConfController {
        public ActionResult Index() {
            using (var context = Context) {
                return View(context.Speakers.ToList());
            }
        }
    }
}
