using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Models;
using System.Diagnostics;

namespace ChemeaseWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Guides()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
		public IActionResult Testimonials()
		{
			return View();
		}
		public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult PCM()
        {
            return View();
        }
		public IActionResult Register()
		{
			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }
    
        public IActionResult Homepage()
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
