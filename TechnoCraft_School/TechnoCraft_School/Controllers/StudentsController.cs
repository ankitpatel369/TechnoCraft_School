using TechnoCraft_School.Utils;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TechnoCraftSchool_Model;
using System.Web;
using System;

namespace TechnoCraft_School.Controllers
{
    public class StudentsController : ControllerBase
    {
        public static StudentHelper helper = new StudentHelper();

        public StudentsController()
        {
            ViewBag.Gender = helper.SelectGender();
            ViewBag.BloodGroup = helper.SelectBloodGroup();
            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "CourseName");
            ViewBag.Standard_ID = new SelectList(db.Standards, "Standard_ID", "StandardName");
            ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "ClassName");
            ViewBag.Division_ID = new SelectList(db.Divisions, "Division_ID", "DivisionName");
            ViewBag.Student_Status_ID = new SelectList(db.Student_Status, "Student_Status_ID", "StudentStatus");
        }
        // GET: Students
        public ActionResult Index()
        {
            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "CourseName");
            ViewBag.Standard_ID = new SelectList(db.Students, "Standard_ID", "StandardName");
            ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "ClassName");

            return View(db.Students.ToList());
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
            //ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "CourseName");
            //ViewBag.Standard_ID = new SelectList(db.Students, "Standard_ID", "StandardName");
            //ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "ClassName");

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Students model, HttpPostedFileBase StudentPhoto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string CourseName = db.Courses.Find(model.Course_ID).CourseName;
                    string StandardName = db.Standards.Find(model.Standard_ID).StandardName;
                    try
                    {
                        using (ImageUploader imageUploader = new ImageUploader())
                        {
                            string fileName = CourseName + '-' + StandardName + '-' + StudentPhoto.FileName + '-' + DateTime.Now.Ticks;
                            string location = Server.MapPath("~/Content/StudentPhotos");
                            model.StudentPhoto = "/Content/StudentPhotos/" + imageUploader.UploadImage(StudentPhoto, fileName, location);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        ModelState.AddModelError("", ex.Message);
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
                    ModelState.AddModelError("", "Model State is not valid.");
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
        public ActionResult Edit(int? id, Students model, HttpPostedFileBase StudentPhoto)
        {
            try
            {
                //ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "CourseName");
                //ViewBag.Standard_ID = new SelectList(db.Students, "Standard_ID", "StandardName");
                //ViewBag.Class_ID = new SelectList(db.Classes, "Class_ID", "ClassName");
                //ViewBag.Student_Status_ID = new SelectList(db.Student_Status, "Student_Status_ID", "StudentStatus");
                if (id == null)
                {
                    ModelState.AddModelError("", "No Student found !");
                    return View();
                }
                if (ModelState.IsValid)
                {
                    var student = db.Students.Attach(model);
                    var studentEntry = db.Entry(model);

                    try
                    {
                        //Upload StudentPhoto here.
                        if (StudentPhoto != null)
                        {
                            using (ImageUploader imageUploader = new ImageUploader())
                            {
                                string fileName = model.StudentPhoto.Replace(' ', '-') + "-" + DateTime.Now.Ticks;

                                string oldImageLocation = Server.MapPath(model.StudentPhoto);
                                string location = Server.MapPath("~/Content/StudentPhotos");
                                model.StudentPhoto = "/Content/StudentPhotos/" + imageUploader.UploadImage(StudentPhoto, fileName, location);

                                imageUploader.DeleteImage(oldImageLocation);
                            }
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(model);
                    }
                    studentEntry.State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
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
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.Students.Find(id);
            db.Students.Remove(students);
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
