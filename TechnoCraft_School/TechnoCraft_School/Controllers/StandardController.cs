using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TechnoCraft_School.Utils;
using TechnoCraftSchool_Model;

namespace TechnoCraft_School.Controllers
{
    [Authorize]
    public class StandardController : ControllerBase
    {
        // GET: Standard
        public ActionResult Index()
        {
            var standards = db.Standards.Include(s => s.Course);
            return View(standards.ToList());
        }

        // GET: Standard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // GET: Standard/Create
        public ActionResult Create()
        {
            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "CourseName");
            return View();
        }

        // POST: Standard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Standard standard)
        {
            if (ModelState.IsValid)
            {
                db.Standards.Add(standard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "CourseName", standard.Course_ID);
            return View(standard);
        }

        // GET: Standard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "CourseName", standard.Course_ID);
            return View(standard);
        }

        // POST: Standard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Standard standard)
        {
            if (id == null) return View(standard);

            if (ModelState.IsValid)
            {
                db.Entry(standard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "CourseName", standard.Course_ID);
            return View(standard);
        }

        // GET: Standard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // POST: Standard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Standard standard = db.Standards.Find(id);
            db.Standards.Remove(standard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
