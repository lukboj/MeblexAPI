using AutoMapper;
using Meblex.Services.Interfaces;
using Meblex.ViewModels;
using MeblexData.Interfaces;
using MeblexData.Models;
using MeblexData.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Meblex.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ShoppingCartController( ShoppingCart shoppingCart, IProductService _productService, IMapper _mapper )
        {
            _shoppingCart = shoppingCart;
            productService = _productService;
            mapper = _mapper;
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

        public async Task<RedirectToActionResult> AddToShoppingCart(int productid)

        {

            var selectedproduct =  productService.GetProductByIdNotAsync(productid);

            if (selectedproduct != null)
            {
                _shoppingCart.AddToCart(selectedproduct, 1);
            }
            return RedirectToAction("index");
        }
        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int productid)
        {
            var selectedproduct =  productService.GetProductByIdNotAsync(productid);


            if (selectedproduct != null)

            {
                _shoppingCart.RemoveFromCart(selectedproduct);
            }
            return RedirectToAction("index");
        }

    }
}

