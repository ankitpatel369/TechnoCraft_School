using TechnoCraft_School.Utils;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web;
using System;
using System.Collections.Generic;
using TechnoCraftSchool_Model;
using TechnoCraft_School.Utils.Notification;

namespace TechnoCraft_School.Controllers
{
    public class StudentsController : ControllerBase
    {
        public static StudentHelper helper = new StudentHelper();

        public StudentsController()
        {
            ViewBag.Gender = helper.SelectGender();
            ViewBag.BloodGroup = helper.SelectBloodGroup();

            List<Course> Courses = db.Courses.ToList();
            Courses.Insert(0, new Course { Course_ID = 0, CourseName = "-- Select Course --" });
            SelectList selectListCourse = new SelectList(Courses, "Course_ID", "CourseName", 0);
            ViewBag.Course_ID = selectListCourse;

            ViewBag.Standard_ID = new SelectList(db.Standards, "Standard_ID", "StandardName");
            ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "ClassName");
            ViewBag.Division_ID = new SelectList(db.Divisions, "Division_ID", "DivisionName");
            ViewBag.Student_Status_ID = new SelectList(db.Student_Status, "Student_Status_ID", "StudentStatus");
        }
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        #region  Fill DropDownList Methods

        [HttpGet]
        [AjaxMessagesFilter]
        public ActionResult GetStandard(int Course_ID)
        {
            if (Course_ID == null)
            {
                this.ShowMessage(MessageType.Error, "Standard not found.", false, true);
                return Json("", JsonRequestBehavior.AllowGet);
            }

            var StandardList = db.Standards.Where(c => c.Course_ID == Course_ID).Select(s => new { s.Standard_ID, s.StandardName });

            return Json(StandardList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AjaxMessagesFilter]
        public ActionResult GetClass(int Standard_ID)
        {
            if (Standard_ID == null)
            {
                this.ShowMessage(MessageType.Error, "Class not found.", false, true);
                return Json("", JsonRequestBehavior.AllowGet);
            }

            var ClassList = db.Classes.Where(c => c.Standard_ID == Standard_ID).Select(c => new { c.Class_ID, c.ClassName });

            return Json(ClassList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AjaxMessagesFilter]
        public ActionResult GetDivision(int Division_ID)
        {
            if (Division_ID == null)
            {
                this.ShowMessage(MessageType.Error, "Division not found.", false, true);
                return Json("", JsonRequestBehavior.AllowGet);
            }

            var DivisionList = db.Divisions.Where(d => d.Division_ID == Division_ID).Select(d => new { d.Division_ID, d.DivisionName });

            return Json(DivisionList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Post: Students
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(int Course_ID, int Standard_ID, int Class_ID)
        {
            try
            {
                ViewBag.StoreData = Course_ID + ',' + Standard_ID + ',' + Class_ID;
                return View(db.Students.Where(s => s.Course_ID == Course_ID).Where(s => s.Standard_ID == Standard_ID).Where(s => s.Class_ID == Class_ID).ToList());
            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, ex.Message, true, false);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Refresh(string StoreData)
        {
            string[] Ids = StoreData.Split(',');
            var StudentList = db.Students.Where(s => s.Course_ID == Convert.ToInt32(Ids[0])).Where(s => s.Standard_ID == Convert.ToInt32(Ids[1])).Where(s => s.Class_ID == Convert.ToInt32(Ids[2])).ToList();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Students model, HttpPostedFileBase StudentPhoto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tryCatchFileName = string.Empty;
                    try
                    {
                        using (ImageUploader imageUploader = new ImageUploader())
                        {
                            //string fileName = StudentPhoto.FileName.Replace(' ', '-') + "-" + DateTime.Now.Ticks;

                            string fileName = Guid.NewGuid().ToString("N") + '-' + StudentPhoto.FileName;
                            string location = Server.MapPath("~/Content/StudentPhotos");
                            model.StudentPhoto = "/Content/StudentPhotos/" + imageUploader.UploadImage(StudentPhoto, fileName.Trim(), location);
                            tryCatchFileName = fileName;

                        }
                    }
                    catch (Exception ex)
                    {
                        using (ImageUploader imageUploader = new ImageUploader())
                        {
                            imageUploader.DeleteImage(tryCatchFileName);
                        }
                        AddModelErrors(ex.Message);
                        return View(model);
                    }

                    model.Date_Of_Admission = DateTime.Now;
                    model.Year_Of_Admission = DateTime.Now.Year.ToString();

                    db.Students.Add(model);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    AddModelErrors();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Students students = db.Students.Find(id);
                if (students == null)
                {
                    return HttpNotFound();
                }
                return View(students);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string ProfilePic, /*[Bind(Exclude = "Date_Of_Admission,Year_Of_Admission,Student_Status_ID")]*/ Students model, HttpPostedFileBase StudentPhoto)
        {
            try
            {
                if (id == null)
                {
                    AddModelErrors();
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        var student = db.Students.Attach(model);
                        var studentEntry = db.Entry(model);

                        string tryCatchFileName = string.Empty;
                        try
                        {
                            //Upload StudentPhoto here.
                            if (StudentPhoto != null)
                            {
                                using (ImageUploader imageUploader = new ImageUploader())
                                {
                                    //string fileName = StudentPhoto.FileName.Replace(' ', '-') + "-" + DateTime.Now.Ticks;
                                    ;
                                    string fileName = Guid.NewGuid().ToString("N") + '-' + StudentPhoto.FileName;
                                    string location = Server.MapPath("~/Content/StudentPhotos");
                                    model.StudentPhoto = "/Content/StudentPhotos/" + imageUploader.UploadImage(StudentPhoto, fileName.Trim(), location);
                                    tryCatchFileName = fileName;

                                    imageUploader.DeleteImage(ProfilePic);
                                }
                            }
                            else
                            {
                                model.StudentPhoto = ProfilePic;
                            }
                        }
                        catch (Exception ex)
                        {
                            using (ImageUploader imageUploader = new ImageUploader())
                            {
                                imageUploader.DeleteImage(tryCatchFileName);
                            }
                            AddModelErrors(ex.Message);
                            return View(model);
                        }
                        studentEntry.State = EntityState.Modified;
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        AddModelErrors(ex.Message);
                        return View(model);
                    }
                }
                AddModelErrors();
                return View(model);
            }
            catch (Exception ex)
            {
                AddModelErrors(ex.Message);
                return View(model);
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [AjaxMessagesFilter]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                db.Students.Remove(db.Students.Find(id));
                db.SaveChanges();
                this.ShowMessage(MessageType.Success, "Record is added successfully.");
                return Json(true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                this.ShowMessage(MessageType.Error, "Error while deleting record.");
                return Json(true);
            }
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
