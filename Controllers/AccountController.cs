using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Homepage()
        { 
            return RedirectToAction("Homepage", "Home");
        }
    }
}
