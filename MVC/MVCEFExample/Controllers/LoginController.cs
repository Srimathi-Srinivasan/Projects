using Microsoft.AspNetCore.Mvc;
using MVCEFExample.Models;

namespace MVCEFExample.Controllers
{
    public class LoginController : Controller
    {
        private readonly ShopContext db;
        private readonly ISession session;
        
        public LoginController(ShopContext _db,IHttpContextAccessor httpContextAccessor)
        { 
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(Userdata user)
        {
            if(ModelState.IsValid)
            {
                db.Userdata.Add(user);
                db.SaveChanges();
                return RedirectToAction("login");
            }
            else
            {
                return View();
            }
            
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(Userdata user)
        {
            var result = (from i in db.Userdata
                          where i.Uname == user.Uname && i.Password == user.Password select i).SingleOrDefault();
            if(result != null)
            {
                HttpContext.Session.SetString("Username", user.Uname);
                return RedirectToAction("ProductDetails", "Product");
            }
            return RedirectToAction("login");
        }

        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return View("login");
        }
    }
}
