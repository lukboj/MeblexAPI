using Meblex.ViewModels;
using MeblexData.Interfaces;
using MeblexData.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Meblex.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int productid)

        {
            var selectedproduct = _productRepository.Products.FirstOrDefault(p => p.ProductID == productid);
            if (selectedproduct != null)
            {
                _shoppingCart.AddToCart(selectedproduct, 1);
            }
            return RedirectToAction("index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int productid)
        {
            var selecetedproduct = _productRepository.Products.FirstOrDefault(p => p.ProductID == productid);
            if (selecetedproduct != null)
            {
                _shoppingCart.RemoveFromCart(selecetedproduct);
            }
            return RedirectToAction("index");
        }

    }
}

