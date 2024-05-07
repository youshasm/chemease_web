using ChemeaseWeb.Data.DataModel;
using ChemeaseWeb.Extensions;
using ChemeaseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstMVC.Models;
using System.Diagnostics;

namespace ChemeaseWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryDBContext _dbContext;
		
		public HomeController(ILogger<HomeController> logger,InventoryDBContext context)
        {
            _logger = logger;	
            _dbContext = context;
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
            var products = _dbContext.Products.ToList();

            // Pass the products to the view
            return View(products);
            //return View();

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
		public IActionResult Cart()
		{
			var cartItems = GetCartItemsFromStorage();
			return View("~/Views/Home/Cart.cshtml", cartItems);
		}
	

		[HttpPost]
		public IActionResult AddToCart(int productId, int quantity, string productName, string productDescription, decimal unitPrice)
		{
			var cartItem = new CartViewModel
			{
				ProductID = productId,
				ProductName = productName,
				ProductDescription = productDescription,
				UnitPrice = unitPrice,
				Quantity = quantity
			};

			AddCartItemToStorage(cartItem);

			return Json(new { success = true, message = "Product added to cart successfully!" });
		}

		private List<CartViewModel> GetCartItemsFromStorage()
		{
			// Retrieve cart items from storage (e.g., session)
			var cartItems = HttpContext.Session.GetObject<List<CartViewModel>>("CartItems");
			return cartItems ?? new List<CartViewModel>();
		}

		private void AddCartItemToStorage(CartViewModel cartItem)
		{
			var cartItems = HttpContext.Session.GetObject<List<CartViewModel>>("CartItems") ?? new List<CartViewModel>();
			var existingItem = cartItems.FirstOrDefault(item => item.ProductID == cartItem.ProductID);

			if (existingItem != null)
			{
				// Item already exists, increase its quantity by 1
				existingItem.Quantity++;
			}
			else
			{
				// Item doesn't exist, add it to the cart
				cartItems.Add(cartItem);
			}

			// Save the updated cart items to storage (e.g., session)
			HttpContext.Session.SetObject("CartItems", cartItems);
		}
	}
}
