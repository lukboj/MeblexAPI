using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using Meblex.ViewModels;
using MeblexData.Interfaces;
using MeblexData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meblex.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }


        public async Task<ViewResult> List(string? category)
        {
            string _category = category;
            IEnumerable<ProductDTO> products;

            string currentcategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = await productService.GetProducts();

               
                currentcategory = "Wszystkie produkty";

                var plvm = new ProductListViewModel
                {
                    Products = products,
                    CurrentCategory = currentcategory

                };
                return View(plvm);
            }

            products = await productService.GetProductsByCategoryId(category);

            var pvm = new ProductListViewModel
            {
                Products = products,
                CurrentCategory = category

            };

            return View(pvm);


        }
        public async  Task<IActionResult> Index()
        {
            return View( );
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetProductById(id); 

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
