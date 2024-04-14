using Microsoft.AspNetCore.Mvc;
namespace ChemeaseWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PCM()
        {
            return View();
        }
    }
}
