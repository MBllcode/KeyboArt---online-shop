using KeyboArt.Data;
using KeyboArt.Data.Cart;
using KeyboArt.Data.Services;
using KeyboArt.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KeyboArt.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IProductsService productsService, ShoppingCart shoppingCart, IOrdersService ordersService, AppDbContext context)
        {
            _productsService = productsService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public ActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var item = await _productsService.GetByIdAsync(id);

            if (item != null && item.Quantity > 0 && User.Identity.IsAuthenticated)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _productsService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAdress = User.FindFirstValue(ClaimTypes.Email);
            DateTime date = DateTime.Now;

            if(_shoppingCart.ShoppingCartItems .Count > 0)
            {
                await _ordersService.StoreOrderAsync(items, userId, userEmailAdress, date);
                await _shoppingCart.ClearShoppingCartAsync();
                return View("OrderCompleted");
            }


            return View("ShoppingCart");
        }

        public async Task<IActionResult> CheckOrder(int id)
        {
            var item = await _context.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();

            if(item != null)
            {
               item.Status = true;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));           
        }
    }
}

