using Microsoft.AspNetCore.Mvc;
using MVCSimpleDemo.Models;
using System.Diagnostics;

namespace MVCSimpleDemo.Controllers
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

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        // Custom Action Method
        public IActionResult Square()
        {
            int num = 5;
            var square = num * num;
            return Content(square.ToString());   // dont need view, since we just want to print without html styling. Available to see at /home/square (/controllername/method)
        }

        public IActionResult TestError()
        {
            int x = 10;
            int y = 0;
            int result = x / y;

            return Content(result.ToString());  // Content() for directly printing content to the page (w/o views)
        }

        public IActionResult Error()
        {
            return View();   // Refers to the view of the error
        }

    }
}
