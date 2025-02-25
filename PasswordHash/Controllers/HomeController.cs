// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace SecureAuthApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
