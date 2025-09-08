using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Controllers
{
    public class HomeController : Controller
    {
        //this class was auto-generated like this. no additional code has been added
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
