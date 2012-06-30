namespace aspConf {
    using System.Web.Mvc;
    using aspConf.Controllers;
    using aspConf.Controllers.Models;

    public class SponsorGlobalFilter : IResultFilter {
        public void OnResultExecuting(ResultExecutingContext filterContext) {
            if ((filterContext.Controller is SponsorsController)) return;

            filterContext.Controller.ViewBag.Sponsors = new ConfRepository().GetActiveSposors();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) {
        }
    }
}