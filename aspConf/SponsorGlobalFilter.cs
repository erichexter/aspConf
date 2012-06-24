namespace aspConf {
    using System.Linq;
    using System.Web.Mvc;
    using aspConf.Model;
    using aspConf.Controllers;

    public class SponsorGlobalFilter : IResultFilter {
        public void OnResultExecuting(ResultExecutingContext filterContext) {
            if ((filterContext.Controller is SponsorsController)) return;
            
            using (var context = new ConfContext()) {
                filterContext.Controller.ViewBag.Sponsors = context.Sponsors.ToList();
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) {
        }
    }
}