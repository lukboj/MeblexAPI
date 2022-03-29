using MeblexData.Interfaces;
using MeblexData.Models.Order;
using MeblexData.Models.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meblex.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        [Authorize]

        public IActionResult CheckOut(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (_shoppingCart.ShoppingCartItems.Count ==0)
            {
                ModelState.AddModelError("", "Twój wózek jest pusty, dodaj meble do koszyka");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.createOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);
        }

        public IActionResult CheckOutComplete()
        {
            ViewBag.CheckoutMessage = "Dziękujemy za zamówienie";
            return View();
        }
            
        public IActionResult YourOrders()
        {
            return View(_orderRepository.GetUserOrders());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _orderRepository.GetUserOrderByIdAsync(id));
        }



    }
}
