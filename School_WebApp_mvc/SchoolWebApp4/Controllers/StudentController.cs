using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolWebApp4.Controllers
{
    public class StudentController : Controller
    {
        SchoolContext db = new SchoolContext();
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = db.Students.Where(x => x.id == id).First();
            var school = db.Schools.Where(x => x.id == student.id).First();
            student.School = school;
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.school_id = new SelectList(db.Schools, "id", "school_name");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.school_id = new SelectList(db.Schools, "school_id", "school_name", student.school_id);
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.Students.Where(x => x.id == id).First();
            ViewBag.school_id = new SelectList(db.Schools, "id", "school_name", student.school_id);

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student formData)
        {
            var student = db.Students.Where(x => x.id == id).First();
            student.name = formData.name;
            student.age = formData.age;
            student.school_id = formData.school_id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = db.Students.Where(x => x.id == id).First();
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
