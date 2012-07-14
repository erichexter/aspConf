namespace aspConf.Controllers {
    using System.Web.Mvc;

    public class SessionsController : ConfController {
        public ActionResult Index() {
            var result = Repository.GetActiveSessions();
            return View(result);
        }

        public ActionResult Recording() {
            return View();
        }
    }
}
