
namespace aspConf.Areas.admin {
    using System.Web.Mvc;

    public class AdminAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { controller="Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
