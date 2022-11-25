using ElectronicsShoppingMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShoppingMVC.Controllers
{
    public class TelevisionController : Controller
    {
        private readonly ElectronicsShoppingContext db;
        public TelevisionController(ElectronicsShoppingContext _db)
        {
            db = _db;
        }
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(Television t)
        {
            return View();
        }

        public IActionResult SpecificTV(int id)
        {
            Television t = db.Televisions.Find(id);
            //var result = db.Televisions.Where(x => x.Id == id).Select(x => x).SingleOrDefault();
            return View(t);
        }

        public IActionResult SmartTV()
        {
            return View();
        }

        public IActionResult AndroidTV()
        {
            return View();
        }

        
    }
}
