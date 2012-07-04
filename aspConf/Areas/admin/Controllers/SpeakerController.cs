namespace aspConf.Areas.admin.Controllers {
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using aspConf.Model;


    public class SpeakerController : Controller
    {
        private ConfContext db = new ConfContext();

        //
        // GET: /admin/Speaker/

        public ViewResult Index() {
            return View(db.Speakers.ToList());
        }

        //
        // GET: /admin/Speaker/Details/5

        public ViewResult Details(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            return View(speaker);
        }

        //
        // GET: /admin/Speaker/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /admin/Speaker/Create

        [HttpPost]
        public ActionResult Create(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                db.Speakers.Add(speaker);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(speaker);
        }
        
        //
        // GET: /admin/Speaker/Edit/5
 
        public ActionResult Edit(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            return View(speaker);
        }

        //
        // POST: /admin/Speaker/Edit/5

        [HttpPost]
        public ActionResult Edit(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speaker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speaker);
        }

        //
        // GET: /admin/Speaker/Delete/5
 
        public ActionResult Delete(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            return View(speaker);
        }

        //
        // POST: /admin/Speaker/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Speaker speaker = db.Speakers.Find(id);
            db.Speakers.Remove(speaker);
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
