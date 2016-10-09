using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TechnoCraft_School.Utils;
using TechnoCraftSchool_Model;

namespace TechnoCraft_School.Controllers
{
    [Authorize]
    public class InstituteController : ControllerBase
    {
        public InstituteController()
        {

        }

        // GET: Institute
        public ActionResult Index()
        {
            try
            {
                var institutes = db.Institutes.ToList().SingleOrDefault();

                return View(institutes);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: Institute/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Institute model)
        {
            try
            {
                string str = Request.Params["save"];
                if (str.Equals("Approve"))
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(model).State = EntityState.Modified;
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View(model);
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        // GET: Institute/Add

        public ActionResult Add()
        {
            return View();
        }

        // POST: Institute/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Institute model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedAt = DateTime.Now;
                    model.UpdatedAt = DateTime.Now;

                    db.Institutes.Add(model);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    AddModelErrors();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }


        // GET: Institute/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute Institute = db.Institutes.Find(id);
            if (Institute == null)
            {
                return HttpNotFound();
            }
            return View(Institute);
        }



        // GET: Institute/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null) return View();
                Institute institute = db.Institutes.Where(b => b.Id == id).FirstOrDefault();
                return View(institute);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: Institute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Institute model)
        {
            try
            {
                if (id == null) return View();
                
                if (ModelState.IsValid)
                {
                    var Institute = db.Institutes.Attach(model);
                    var InstituteEntry = db.Entry(model);

                    model.CreatedAt = DateTime.Now;
                    model.UpdatedAt = DateTime.Now;

                    InstituteEntry.State = EntityState.Modified;
                    db.SaveChanges();

                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: Institute/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute Institute = db.Institutes.Find(id);
            if (Institute == null)
            {
                return HttpNotFound();
            }
            return View(Institute);
        }

        // POST: Institute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Institute Institute = db.Institutes.Find(id);
            db.Institutes.Remove(Institute);
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
