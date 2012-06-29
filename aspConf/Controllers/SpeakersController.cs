namespace aspConf.Controllers {
    using System.Linq;
    using System.Web.Mvc;

    public class SpeakersController : ConfController {
        public ActionResult Index() {
            using (var context = Context) {
                var list = context.Speakers
                    .Where(sp => sp.IsActive)
                    .ToList();

                return View(list);
            }
        }
    }
}
