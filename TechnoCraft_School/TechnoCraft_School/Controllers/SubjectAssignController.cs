using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechnoCraftSchool_Model;
using TechnoCraft_School.Models;
using TechnoCraft_School.Utils.Notification;

namespace TechnoCraft_School.Controllers
{
    public class SubjectAssignController : ControllerBase
    {

        #region Get Assign Subjects
        // GET: SubjectAssign
        public ActionResult Index()
        {
            var subjectAssigns = db.SubjectAssigns.Include(s => s.Subjects);
            return View(subjectAssigns.ToList());
        }
        #endregion

        #region Assign Subject Details
        // GET: SubjectAssign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectAssign subjectAssign = db.SubjectAssigns.Find(id);
            if (subjectAssign == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", subjectAssign);
        }
        #endregion

        #region Assign Subject To Courss Or Standard
        // GET: SubjectAssign/Create
        public ActionResult Create()
        {
            ViewBag.Subject_ID = new SelectList(db.Subjects, "Subject_ID", "SubjectName");
            return PartialView("_AssignSubject");
        }

        // POST: SubjectAssign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxMessagesFilter]
        public ActionResult Create(SubjectAssign model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.SubjectAssigns.Add(model);
                        db.SaveChanges();
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        this.ShowMessage(MessageType.Error, AddModelErrors(ex.Message), false, true);
                        return Json(false);
                    }
                }

                ViewBag.Subject_ID = new SelectList(db.Subjects, "Subject_ID", "SubjectName", model.Subject_ID);

                return PartialView("_AssignSubject", model);
            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, "Error while inserting record.");
                return Json(false);
            }
        }

        #endregion

        #region Update Assign Subjects
        // GET: SubjectAssign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectAssign subjectAssign = db.SubjectAssigns.Find(id);
            if (subjectAssign == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subject_ID = new SelectList(db.Subjects, "Subject_ID", "SubjectName", subjectAssign.Subject_ID);
            return PartialView("_EditAssignSubject", subjectAssign);
        }

        // POST: SubjectAssign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxMessagesFilter]
        public ActionResult Edit(SubjectAssign subjectAssign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Entry(subjectAssign).State = EntityState.Modified;
                        db.SaveChanges();
                        this.ShowMessage(MessageType.Success, "Record is updated.", false, true);
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        this.ShowMessage(MessageType.Error, AddModelErrors(ex.Message), false, true);
                        return Json(false);
                    }
                }
                ViewBag.Subject_ID = new SelectList(db.Subjects, "Subject_ID", "SubjectName", subjectAssign.Subject_ID);
                return Json(subjectAssign, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, "Error while updating record.");
                return Json(false);
            }
        }

        #endregion

        #region Delete Assign Subjects
        // GET: SubjectAssign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectAssign subjectAssign = db.SubjectAssigns.Find(id);
            if (subjectAssign == null)
            {
                return HttpNotFound();
            }
            return View(subjectAssign);
        }

        // POST: SubjectAssign/Delete/5
        [HttpPost, ActionName("Delete")]
        [AjaxMessagesFilter]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                db.SubjectAssigns.Remove(db.SubjectAssigns.Find(id));
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, "Error while deleteing record.");
                return Json(false);
            }
        }
        #endregion

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
