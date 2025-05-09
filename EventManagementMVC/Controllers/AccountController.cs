using EventsCore.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(SignUpDTO userData)
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Signup()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Signup(SignUpDTO userData)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
