using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TechnoCraft_School.Utils;
using TechnoCraftSchool_Model;

namespace TechnoCraft_School.Controllers
{
    [Authorize]
    public class AcademicYearController : ControllerBase
    {

        // GET: AcademicYear
        public ActionResult Index()
        {
            return View(db.AcademicYears.ToList());
        }

        // GET: AcademicYear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // GET: AcademicYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicYear/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                db.AcademicYears.Add(academicYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicYear);
        }

        // GET: AcademicYear/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYear/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicYear);
        }

        // GET: AcademicYear/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicYear academicYear = db.AcademicYears.Find(id);
            db.AcademicYears.Remove(academicYear);
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
