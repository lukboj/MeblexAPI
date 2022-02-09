using MeblexData.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MeblexData.Models.ShoppingCart
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;


        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartitem =
                _appDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Product.ProductID == product.ProductID && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartitem == null)
            {
                shoppingCartitem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartitem);
            }
            else
            {
                shoppingCartitem.Amount++;
            }


            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartitem =
                _appDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Product.ProductID == product.ProductID && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartitem != null)
            {
                if (shoppingCartitem.Amount > 1)
                {
                    shoppingCartitem.Amount--;
                    localAmount = shoppingCartitem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartitem);

                };

            }

            _appDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                _appDbContext.ShoppingCartItems.Where(b => b.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Product)
                .ToList());

        }

        public void ClearCart()
        {
            var caritems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _appDbContext.ShoppingCartItems.RemoveRange(caritems);
            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;

        }
    }
}