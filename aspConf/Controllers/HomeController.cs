namespace aspConf.Controllers {
    using System.Web.Mvc;

    public class HomeController : ConfController {
        public ActionResult Index() {
            return View();
        }
    }
}
