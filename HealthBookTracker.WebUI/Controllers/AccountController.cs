using Microsoft.AspNetCore.Mvc;

namespace HealthBookTracker.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private const string HardCodedPassword = "Mafia2018"; // теперь используется

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string password)
        {
            if (password == HardCodedPassword)
            {
                HttpContext.Session.SetString("LoggedIn", "true");
                return RedirectToAction("Index", "Employees");
            }
            ViewBag.Error = "Неверный пароль";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoggedIn");
            return RedirectToAction("Login");
        }
    }
}
