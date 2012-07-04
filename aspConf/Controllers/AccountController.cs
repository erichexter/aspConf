namespace aspConf.Controllers {
    using aspConf.Models;
    using System.Web.Mvc;
    using System.Web.Security;

    public class AccountController : Controller {
        public ActionResult LogOn() {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl) {
            if (ModelState.IsValid) {
                if (FormsAuthentication.Authenticate(model.UserName, model.Password)) {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\")) {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        public ActionResult LogOff() {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
