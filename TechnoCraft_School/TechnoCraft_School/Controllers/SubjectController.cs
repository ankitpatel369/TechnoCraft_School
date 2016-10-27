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
    [Authorize]
    public class SubjectController : ControllerBase
    {
        #region Subject

        #region Get Subject
        // GET: Subject
        public ActionResult Index()
        {
            return View(db.Subjects.ToList());
        }

        [HttpPost]
        public ActionResult Refresh()
        {
            return Json(db.Subjects, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Subject Details
        // GET: Subject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        #endregion

        #region Create New Subject
        // GET: Subject/Create
        public ActionResult AddSubject()
        {
            return PartialView("_AddSubject");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxMessagesFilter]
        public ActionResult AddSubject(Subject model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Subjects.Add(model);
                    db.SaveChanges();
                    ModelState.Clear();
                    this.ShowMessage(MessageType.Success, "Subject Add Succefully.");
                    return Json(true);
                }
                else
                {
                    this.ShowMessage(MessageType.Error, AddModelErrors(), false, true);
                    return Json(false);
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, "Error occurred while adding Subject.", false, true);
                return Json(false);
            }
        }

        #endregion

        #region  Edit Subject
        [HttpGet]
        public ActionResult EditSubject(int id)
        {
            Subject data = db.Subjects.Find(id);
            return PartialView("_EditSubject", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxMessagesFilter]
        public ActionResult EditSubject(Subject model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var EditSubject = db.Subjects.Attach(model);
                    var SubjectEntry = db.Entry(model);

                    SubjectEntry.State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    this.ShowMessage(MessageType.Success, "Record is updated successfully.");
                    return Json(true);
                }
                else
                {
                    this.ShowMessage(MessageType.Error, AddModelErrors(), false, true);
                    return Json(false);
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, "Error while updating record.");
                return Json(false);
            }
        }
        #endregion

        #region Subject Delete
        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [AjaxMessagesFilter]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            this.ShowMessage(MessageType.Success, "Subject Remove Succefully.", false, true);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion 

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
