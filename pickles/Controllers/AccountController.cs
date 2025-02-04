using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMVP.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserMVP.Controllers
{
    public class AccountController : Controller
    {
        private static List<User> users = new List<User>(); // Simulated DB

        // GET: Login Page (Default)
        public IActionResult Login()
        {
            return View();
        }

        // POST: Validate Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
           //     HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("Dashboard");
            }
            ViewBag.Error = "Invalid credentials!";
            return View();
        }

        // GET: Sign Up Page
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: Register New User
        [HttpPost]
        public IActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                model.Id = new Guid();
                users.Add(model);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: Dashboard (After login)
        public IActionResult Dashboard()
        {
/*            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login");*/

            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
