using Microsoft.AspNetCore.Mvc;
using ChemeaseWeb.Models;
using ChemeaseWeb.Models.tables;
using Microsoft.EntityFrameworkCore;
using ChemeaseWeb.Data.DataModel;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ChemeaseWeb.Extensions;
using Newtonsoft.Json;

namespace ChemeaseWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly InventoryDBContext _dbContext;
        private readonly ILogger<ShoppingCartController> _logger;
        public ShoppingCartController(InventoryDBContext context,ILogger<ShoppingCartController> logger)
        {
            _dbContext = context;_logger = logger;
        }

        public IActionResult Index()
		{
			//var cartItem = new CartViewModel
			//{
			//	ProductID = 2,
			//	ProductName = "Amber",
			//	ProductDescription = "This is a test product",
			//	UnitPrice = 19.99m,
			//	Quantity = 2
			//};

			//// Create a list of cart items and add the hardcoded item
			//var cartItems = new List<CartViewModel> { cartItem };
			var cartItems = GetCartItemsFromStorage();
			//return View(cartItems);
			return View("~/Views/Home/Cart.cshtml", cartItems);
        }
		public IActionResult TestCart()
        {
            var cartItem = new CartViewModel
            {
                ProductID = 1,
                ProductName = "Test Product",
                ProductDescription = "This is a test product",
                UnitPrice = 19.99m,
                Quantity = 2
            };

            var cartItems = new List<CartViewModel> { cartItem };

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

            cartItems.Add(cartItem);

            // Save the updated cart items to storage (e.g., session)
            HttpContext.Session.SetObject("CartItems", cartItems);
        }
    }
}
