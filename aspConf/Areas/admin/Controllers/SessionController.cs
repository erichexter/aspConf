namespace aspConf.Areas.admin.Controllers {
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using aspConf.Model;

    public class SessionController : Controller
    {
        private ConfContext db = new ConfContext();

        //
        // GET: /admin/Session/

        public ViewResult Index()
        {
            var sessions = db.Sessions.Include(s => s.Speaker);
            return View(sessions.ToList());
        }

        //
        // GET: /admin/Session/Details/5

        public ViewResult Details(int id)
        {
            Session session = db.Sessions.Find(id);
            return View(session);
        }

        //
        // GET: /admin/Session/Create

        public ActionResult Create()
        {
            ViewBag.SpeakerId = new SelectList(db.Speakers, "SpeakerId", "FullName");
            return View();
        } 

        //
        // POST: /admin/Session/Create

        [HttpPost]
        public ActionResult Create(Session session)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.SpeakerId = new SelectList(db.Speakers, "SpeakerId", "FullName", session.SpeakerId);
            return View(session);
        }
        
        //
        // GET: /admin/Session/Edit/5
 
        public ActionResult Edit(int id)
        {
            Session session = db.Sessions.Find(id);
            ViewBag.SpeakerId = new SelectList(db.Speakers, "SpeakerId", "FullName", session.SpeakerId);
            return View(session);
        }

        //
        // POST: /admin/Session/Edit/5

        [HttpPost]
        public ActionResult Edit(Session session)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpeakerId = new SelectList(db.Speakers, "SpeakerId", "FullName", session.SpeakerId);
            return View(session);
        }

        //
        // GET: /admin/Session/Delete/5
 
        public ActionResult Delete(int id)
        {
            Session session = db.Sessions.Find(id);
            return View(session);
        }

        //
        // POST: /admin/Session/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Session session = db.Sessions.Find(id);
            db.Sessions.Remove(session);
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