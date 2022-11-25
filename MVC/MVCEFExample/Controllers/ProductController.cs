using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCEFExample.Models;

namespace MVCEFExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopContext db;
        public ProductController(ShopContext _db)
        {
            db = _db;
        }
        public IActionResult ProductDetails()
        {
            ViewBag.username = HttpContext.Session.GetString("Username");
            if (ViewBag.username != null)
            {
                var res = db.Products.Include(x => x.Supp);
                return View(res.ToList());
            }
            else
            {
                
                return RedirectToAction("login", "Login");
            }
        }
        

        public IActionResult AddNewProd()
        {
            var res = db.Suppliers.ToList();
            ViewBag.Suppid = new SelectList(res, "Sid", "Sname");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProd(Product p)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("ProductDetails");
        }

        public IActionResult Details(int id)
        {
            
            var res = db.Products.Include(x => x.Supp).Where(x=> x.Pid == id).Select(x=>x).SingleOrDefault();
            return View(res);
        }

        public IActionResult Edit(int id)
        {
            Product p = db.Products.Find(id);
            var res = db.Suppliers.ToList();
            ViewBag.Suppid = new SelectList(res, "Sid", "Sname");
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            db.Products.Update(p);
            db.SaveChanges();
            return RedirectToAction("ProductDetails");
        }

        public IActionResult Delete(int id)
        {
            var res = db.Products.Include(x => x.Supp).Where(x => x.Pid == id).Select(x => x).SingleOrDefault();
            return View(res);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(Product p)
        {
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("ProductDetails");
        }





    }
}
