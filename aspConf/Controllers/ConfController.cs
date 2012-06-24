namespace aspConf.Controllers {
    using System.Web.Mvc;
    using aspConf.Model;

    public abstract class ConfController : Controller {
        protected ConfController() {
            Context = new ConfContext();
        }

        public ConfContext Context { get; protected set; }
    }
}