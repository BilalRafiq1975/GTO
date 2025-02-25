// Controllers/AccountController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureAuthApp.Data;
using SecureAuthApp.Models;
using BCrypt.Net;

namespace SecureAuthApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }
        
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Username and password are required.";
                return View();
            }
            
            // Check if the username already exists
            if (await _context.Users.AnyAsync(u => u.Username == username))
            {
                ViewBag.Error = "Username already exists.";
                return View();
            }
            
            // Hash the password using BCrypt
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            
            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash
            };
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            // Redirect to Login after successful registration
            return RedirectToAction("Login");
        }
        
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }
        
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Username and password are required.";
                return View();
            }
            
            // Retrieve user from the database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }
            
            // For demonstration, redirect to Home/Index on successful login
            return RedirectToAction("Index", "Home");
        }
    }
}
