using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;
using Microsoft.AspNetCore.Http;

namespace FirstMVCApp.Controllers
{
    public class PenController : Controller
    {
        public static Pen p = new Pen();
        //public static Pen p1 = new Pen();
        public static List<Pen> pens = p.getPenDetails();

        public string message()
        {
            return "Welcome";
        }

        public ContentResult msg()
        {
            return Content("Welcome");
        }

        //public EmptyResult Initialize()
        //{
        //    pens.Clear();
        //    p.PenId = 101;
        //    p.PenName = "Parker";
        //    p.Price = 400;
        //    p1.PenId = 102;
        //    p1.PenName = "Ronalds";
        //    p1.Price = 500;
        //    pens.Add(p);
        //    pens.Add(p1);
        //    return new EmptyResult();
        //}
        public IActionResult PenDetail()
        {
            //Initialize();
            p.PenId = 101;
            p.PenName = "Parker";
            p.Price = 400;
            return View(p);
        }

        public IActionResult PenDetails()
        {
            //Initialize();            
            return View(pens);
        }

        public IActionResult ScaffoldedPenDetails()
        {
            //Initialize();

            return View(pens);
        }
        [HttpGet]
        public IActionResult AddNewPen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPen(Pen p)
        {
            pens.Add(p);
            return RedirectToAction("ScaffoldedPenDetails");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpContext.Session.SetString("pid", id.ToString());
            p = pens.Where(x => x.PenId == id).Select(x=>x).SingleOrDefault();
            return View(p);
        }

        [HttpPost]

        public IActionResult Edit(Pen p)
        {
            string pid = HttpContext.Session.GetString("pid");
            int id = Convert.ToInt32(pid);
            //int id = p.PenId;            
            Pen oldpen = pens.Where(x => x.PenId == id).Select(x => x).SingleOrDefault();
            pens.Remove(oldpen);
            p.PenId = id;
            pens.Add(p);
            return RedirectToAction("ScaffoldedPenDetails");

        }

        public IActionResult Details(int id)
        {
            p = pens.Where(x => x.PenId == id).Select(x => x).SingleOrDefault();
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            p = pens.Where(x => x.PenId == id).Select(x => x).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            
            p = pens.Where(x => x.PenId == id).Select(x => x).SingleOrDefault();
            pens.Remove(p);
            return RedirectToAction("ScaffoldedPenDetails");
        }
    }
}
