using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    public class CourseListsController : Controller
    {
        private StudentsContext db = new StudentsContext();

        // GET: CourseLists
        public ActionResult Index()
        {
            var corsesList = db.CorsesList.Include(c => c.Course).Include(c => c.Student);
            return View(corsesList.ToList());
        }

        // GET: CourseLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseList courseList = db.CorsesList.Find(id);
            if (courseList == null)
            {
                return HttpNotFound();
            }
            return View(courseList);
        }

        // GET: CourseLists/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Corses, "Id", "CourseName");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FullName");
            return View();
        }

        // POST: CourseLists/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,StudentId,Durtation,HolidayStartDay,HolidayEndDate")] CourseList courseList)
        {
            if (ModelState.IsValid)
            {
                db.CorsesList.Add(courseList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Corses, "Id", "CourseName", courseList.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FullName", courseList.StudentId);
            return View(courseList);
        }

        // GET: CourseLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseList courseList = db.CorsesList.Find(id);
            if (courseList == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Corses, "Id", "CourseName", courseList.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FullName", courseList.StudentId);
            return View(courseList);
        }

        // POST: CourseLists/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,StudentId,Durtation,HolidayStartDay,HolidayEndDate")] CourseList courseList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Corses, "Id", "CourseName", courseList.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FullName", courseList.StudentId);
            return View(courseList);
        }

        // GET: CourseLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseList courseList = db.CorsesList.Find(id);
            if (courseList == null)
            {
                return HttpNotFound();
            }
            return View(courseList);
        }

        // POST: CourseLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseList courseList = db.CorsesList.Find(id);
            db.CorsesList.Remove(courseList);
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
