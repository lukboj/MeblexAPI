using MeblexData.Data;
using MeblexData.Interfaces;
using MeblexData.Models;
using MeblexData.Models.Order;
using MeblexData.Models.ShoppingCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext ;
        private readonly ShoppingCart _shoppingCart;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
            _httpContextAccessor = httpContextAccessor;
        }
        public void createOrder(Order order)
        {


            order.OrderPlaced = DateTime.Now;
            order.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            order.IsShipped = false;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            _appDbContext.Add(order);
            _appDbContext.SaveChanges();


            var shoppingcartitems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingcartitems)
            {
                var orderdetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.ProductID,
                    OrderId = order.OrderId,
                    Price = item.Product.Price
                };
                _appDbContext.OrdersDetails.Add(orderdetail);
            }
            _appDbContext.SaveChanges();

        }

        public async Task<Order> GetUserOrderByIdAsync(int id)
        {
            string userid =  _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _appDbContext.Orders
                .Include(a => a.OrderDetails)
                .ThenInclude(a => a.Product)
                .Where(a => a.UserId == userid)
                .Where(a => a.OrderId == id)
                .SingleOrDefaultAsync();
        }

        public List<Order> GetUserOrders()
        {
            string userid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _appDbContext.Orders
                .Include(a => a.OrderDetails)
                .ThenInclude(a => a.Product)
                .Where(a => a.UserId == userid).ToList();
        }

    }
}
