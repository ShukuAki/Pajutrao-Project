using Microsoft.AspNetCore.Mvc;
using Pajutrao_Project.Models;
using System.Diagnostics;

namespace Pajutrao_Project.Controllers
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

        public IActionResult LoD()
        {

            return View();
        }

        public IActionResult Logistics()
        {

            return View();
        }
        
        public IActionResult Database()
        {

            return View();
        }
        public IActionResult Canvas()
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
