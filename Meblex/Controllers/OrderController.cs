using AutoMapper;
using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
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
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;


        public OrderController(ShoppingCart shoppingCart, IOrderService _orderService, IMapper _mapper )
        {
            _shoppingCart = shoppingCart;
            orderService = _orderService;
            mapper = _mapper;
            
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CheckOut(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (_shoppingCart.ShoppingCartItems.Count ==0)
            {
                ModelState.AddModelError("", "Twój wózek jest pusty, dodaj meble do koszyka");
            }

            if (ModelState.IsValid)
            {

                var ordertocreate = mapper.Map<OrderDetailsDTO>(order);

                await orderService.createOrder(ordertocreate);
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
            
        public async Task<IActionResult> YourOrders()
        {
            return View(await orderService.GetUserOrders());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await orderService.GetUserOrderByIdAsync(id));
        }



    }
}
