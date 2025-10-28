using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

namespace HealthRecord1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string subject, string message)
        {
            TempData["SuccessMessage"] = "تم إرسال رسالتك بنجاح! سنتواصل معك قريباً.";
            return RedirectToAction("Contact");
        }


    }
}
