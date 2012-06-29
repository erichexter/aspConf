namespace aspConf.Controllers {
    using System.Linq;
    using System.Web.Mvc;

    public class SponsorsController : ConfController {
        public ActionResult Index() {
            using (var context = Context) {
                var list = context.Sponsors
                    .Where(sp => sp.IsActive)
                    .ToList();

                return View(list);
            }
        }
    }
}
