//// RegisterController.cs
//using Microsoft.AspNetCore.Mvc;
//using ChemeaseWeb.Models;
//using ChemeaseWeb.Data.DataModel;
//using ChemeaseWeb.Models.tables;
//public class RegisterController : Controller
//{
//    private readonly InventoryDBContext _dbContext;

//    public RegisterController(InventoryDBContext context)
//    {
//        _dbContext = context;
//    }

//    // GET: Register/Create
//    public IActionResult Create()
//    {
//        return View();
//    }

//    // POST: Register/Create
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public IActionResult Create([Bind("Username,Password")] RegisterViewModel register)
//    {
//        if (ModelState.IsValid)
//        {
//            // Map Register model data to UserAccount model
//            var userAccount = new UserAccount
//            {
//                UserName = register.Username,

//                UserPassword = register.Password,
//            };

//            // Add userAccount to UserAccount table
//            _dbContext.UserAccount.Add(userAccount);
//            _dbContext.SaveChanges();

//            return RedirectToAction("Homepage", "Home"); // Redirect to home page after successful registration
//        }
//        return View(register);
//    }
//}
