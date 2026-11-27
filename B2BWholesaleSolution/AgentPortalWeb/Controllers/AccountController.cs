using AgentPortalWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentPortalWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("UserID") != null)
                return RedirectToAction("Index", "Catalog");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Please enter both username and password.";
                return View();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(
                    u => u.UserName == username.Trim() &&
                    u.password == password
                );

            if (user == null)
            {
                ViewBag.Error = "Wrong username or password.";
                return View();
            }

            if (user.@lock)
            {
                ViewBag.Error = "Your agent account is blocked";
                return View();
            }

            if (!string.Equals(user.Role, "Agent", StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.Error = "Admin account cannot order on Agent Web Portal.";
                return View();
            }

            HttpContext.Session.SetInt32("UserID", user.UserID);
            HttpContext.Session.SetString("UserName", user.UserName);

            return RedirectToAction("Index", "Catalog");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
