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
        public IActionResult Contact()
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Signin(string username,string password) // Assuming your LoginViewModel contains username and password fields
        {
            // Validate user credentials here
            // If credentials are valid, redirect to the homepage
            return RedirectToAction("Homepage", "Home");
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
