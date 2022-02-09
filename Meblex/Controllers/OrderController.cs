using MeblexData.Interfaces;
using MeblexData.Models.Order;
using MeblexData.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace Meblex.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
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

    }
}
