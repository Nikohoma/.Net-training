using day35_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace day35_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            _logger.LogInformation("Index page loaded");
            _logger.LogWarning("This is a warning");
            _logger.LogError("This is an error");
            return View();
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
