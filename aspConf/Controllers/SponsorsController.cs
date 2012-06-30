namespace aspConf.Controllers {
    using System.Web.Mvc;

    public class SponsorsController : ConfController {
        public ActionResult Index() {
            var result = Repository.GetActiveSposors();
            return View(result);
        }
    }
}
