namespace aspConf.Areas.admin.Controllers {
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using aspConf.Model;

    public class SponsorController : Controller
    {
        private ConfContext db = new ConfContext();

        public ViewResult Index()
        {
            return View(db.Sponsors.ToList());
        }

        public ViewResult Details(int id)
        {
            Sponsor sponsor = db.Sponsors.Find(id);
            return View(sponsor);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Sponsors.Add(sponsor);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(sponsor);
        }
        
        //
        // GET: /admin/Sponsor/Edit/5
 
        public ActionResult Edit(int id)
        {
            Sponsor sponsor = db.Sponsors.Find(id);
            return View(sponsor);
        }

        //
        // POST: /admin/Sponsor/Edit/5

        [HttpPost]
        public ActionResult Edit(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sponsor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsor);
        }

        //
        // GET: /admin/Sponsor/Delete/5
 
        public ActionResult Delete(int id)
        {
            Sponsor sponsor = db.Sponsors.Find(id);
            return View(sponsor);
        }

        //
        // POST: /admin/Sponsor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Sponsor sponsor = db.Sponsors.Find(id);
            db.Sponsors.Remove(sponsor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}