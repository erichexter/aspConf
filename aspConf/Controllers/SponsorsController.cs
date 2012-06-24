namespace aspConf.Controllers {
    using System.Linq;
    using System.Web.Mvc;

    public class SponsorsController : ConfController {
        public ActionResult Index() {
            return View(Context.Sponsors.ToList());
        }
    }
}
