using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewBag.Models;

namespace ViewBag.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Countries = "India, Russia, France"; // ViewBag is dynamic type. Avoid List : It is heavyweight, it would store in cache
            ViewBag.Subheading = "SubHeading";
            ViewBag.NewBag = new List<string>() { "India, France, Austria" };
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
    }
}
