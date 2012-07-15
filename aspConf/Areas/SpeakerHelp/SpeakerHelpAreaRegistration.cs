using System.Web.Mvc;

namespace aspConf.Areas.SpeakerHelp
{
    public class SpeakerHelpAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SpeakerHelp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SpeakerHelp_default",
                "SpeakerHelp/{controller}/{action}/{id}",
                new {controller="home", action = "Index", id = UrlParameter.Optional }, new string[] { "aspConf.Areas.SpeakerHelp.Controllers"}
            );
        }
    }
}
