namespace aspConf.Controllers {
    using System.Web.Mvc;
    using aspConf.Controllers.Models;

    public abstract class ConfController : Controller {
        protected ConfController() {
            Repository = new ConfRepository();
        }

        public ConfRepository Repository { get; protected set; }       

        public virtual ActionResult Clear() {
            Repository.ClearCache();

            return Redirect("~/");
        }

        public ActionResult Blitz() {
            return Content("42");
        }
    }
}
