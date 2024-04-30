using Microsoft.AspNetCore.Mvc;
using ChemeaseWeb.Models;
using ChemeaseWeb.Data.DataModel;
using ChemeaseWeb.Models.tables;
using System.Linq;

public class AccountController : Controller
{
    private readonly InventoryDBContext _dbContext;

    public AccountController(InventoryDBContext context)
    {
        _dbContext = context;
    }

    // GET: /Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: /Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Map RegisterViewModel data to UserAccount model
            var userAccount = new UserAccount
            {
                UserName = model.Username,
                UserPassword = model.Password,
          
            };

            // Add userAccount to UserAccount table
            _dbContext.UserAccount.Add(userAccount);
            _dbContext.SaveChanges();

            // You may redirect to login page or any other page after successful registration
            return RedirectToAction("Login", "Home");
        }
        return View(model);
    }

    // GET: /Account/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Debugging: Check the values of model.UserName and model.Password
            Console.WriteLine("Username: " + model.UserName);
            Console.WriteLine("Password: " + model.Password);

            // Check if the user exists based on the provided username and password
            var user = _dbContext.UserAccount.FirstOrDefault(u => u.UserName == model.UserName && u.UserPassword == model.Password);

            if (user != null)
            {
                // Authentication successful, you may implement your login logic here
                return RedirectToAction("Homepage", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }
        }

        return View("~/Views/Home/Login.cshtml");

    }
}
