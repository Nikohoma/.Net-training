using Microsoft.AspNetCore.Mvc;
using PartialPostbackExample.Models;
using System.Diagnostics;
using PartialPostbackExample.Models;


namespace PartialPostbackExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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


        [HttpPost]
        public IActionResult GetGreeting(string name)
        {
            return Content($"Hello, {name}! Welcome to ASP.NET AJAX ");
        }

        public IActionResult Status()
        {
            return View();
        }


    }
}
