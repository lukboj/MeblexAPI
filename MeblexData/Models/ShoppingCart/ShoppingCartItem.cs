using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models.ShoppingCart
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
