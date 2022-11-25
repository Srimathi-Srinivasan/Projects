using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCEFEg.Models;

namespace MVCEFEg.Controllers
{
    public class StudentController : Controller
    {
        private readonly eurofinsContext db;

        public StudentController(eurofinsContext _db)
        {
            db = _db;
        }
        public IActionResult StudentDetails()
        {
            var res = db.Students.Include(x => x.Course);        
            return View(res.ToList());
        }

        
        
        public IActionResult AddStudent()
        {
            var res = db.Courses.ToList();
            ViewBag.Courseid = new SelectList(res, "Cid", "Cname");
            return RedirectToAction("StudentDetails");
        }

        [HttpPost]
        public IActionResult AddStudent(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(s);
                db.SaveChanges();
            }
            return RedirectToAction("StudentDetails");
        }

        public IActionResult Edit(int id)
        {
            Student s = db.Students.Find(id);
            var res = db.Courses.ToList();
            ViewBag.Courseid = new SelectList(res, "Cid", "Cname");
            return View(s);
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            db.Students.Update(s);
            db.SaveChanges();
            return RedirectToAction("StudentDetails");
        }

        public IActionResult Details(int id)
        {

            var res = db.Students.Include(x => x.Course).Where(x => x.Courseid == id).Select(x => x).SingleOrDefault();
            return View(res);
        }

        public IActionResult Delete(int id)
        {
            var res = db.Students.Include(x => x.Course).Where(x => x.Courseid == id).Select(x => x).SingleOrDefault();
            return View(res);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(Student s)
        {
            db.Students.Remove(s);
            db.SaveChanges();
            return RedirectToAction("StudentDetails");
        }
    }
}
