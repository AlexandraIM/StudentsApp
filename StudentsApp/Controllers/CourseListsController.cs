using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    public class CourseListsController : Controller
    {
        private StudentsContext db = new StudentsContext();
      
       
        // GET: CourseLists
        public ActionResult Index(string searchStudent)
        {
            var corsesList = db.CorsesList.Include(c => c.Course).Include(c => c.Student);

            if (!String.IsNullOrEmpty(searchStudent))
            {
                corsesList = corsesList.Where(s => s.Student.FullName.Contains(searchStudent));
            }
            
            return View(corsesList.ToList());
        }

      

        // GET: CourseLists/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Corses, "Id", "CourseName");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FullName");
            return View();
        }

        // POST: CourseLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,StudentId,Durtation,StartDate,EndDate,HolidayStartDay,HolidayEndDate")] CourseList courseList)
        {

            var dates = db.CorsesList.Where(cl => cl.StudentId == courseList.StudentId).Select(x => new { x.StartDate, x.EndDate }).ToList();
            bool isValid = true;
            if (dates != null)
            {
                
                dates.ForEach(date => {
                    if (courseList.StartDate < date.EndDate && date.StartDate < courseList.EndDate)
                    {
                        isValid = false;
                    }
                });
            }
            

            if(isValid == false)
            {
                ViewBag.ErroMessage = "You have course on this dates. Choose another!";
                ViewBag.CourseId = new SelectList(db.Corses, "Id", "CourseName", courseList.CourseId);
                ViewBag.StudentId = new SelectList(db.Students, "Id", "FullName", courseList.StudentId);
                return View(courseList);
            }

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
            CourseList course = db.CorsesList.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Corses, "Id", "CourseName", course.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FullName", course.StudentId);
            return View(course);
        }

        // POST: CourseLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,StudentId,Durtation,StartDate,EndDate,HolidayStartDay,HolidayEndDate")] CourseList courseList)
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
            CourseList course = db.CorsesList.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
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
