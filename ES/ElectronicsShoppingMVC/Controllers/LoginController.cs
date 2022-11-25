using ElectronicsShoppingMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShoppingMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ElectronicsShoppingContext db;
        private readonly ISession session;
        public LoginController(ElectronicsShoppingContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Customer c)
        {
            var result = (from i in db.Customers
                          where i.Email == c.Email && i.Password == c.Password
                          select i).SingleOrDefault();
            if(result != null)
            {
                HttpContext.Session.SetString("CustomerName", result.CustomerName);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult MobileNumLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MobileNumLogin(Customer c)
        {
            var result = (from i in db.Customers
                          where i.MobileNumber == c.MobileNumber && i.Password == c.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("CustomerName", result.CustomerName);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(Customer c)
        {
            if(ModelState.IsValid)
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
