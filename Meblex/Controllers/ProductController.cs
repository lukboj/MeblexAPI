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
        private readonly IProductRepository _productRepository;
        private readonly IProductService productService;

        public ProductController(IProductRepository productRepository, IProductService _productService)
        {
            _productRepository = productRepository;
            productService = _productService;
        }


        public ViewResult List(string? category)
        {
            string _category = category;
            IEnumerable<ProductDTO> products;

            string currentcategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
              
                 products = _productRepository.Products
                    .OrderBy(p => p.ProductID)
                    .Select(item => new ProductDTO
                    {
                        ProductID = item.ProductID,
                        Price = item.Price,
                        Category = item.Category,
                        Description = item.Description,
                        ImageUrl= item.ImageUrl,
                        IsPreferred = item.IsPreferred,
                        Name = item.Name,
                    } );
                currentcategory = "Wszystkie produkty";

                var plvm = new ProductListViewModel
                {
                    Products = products,
                    CurrentCategory = currentcategory

                };
                return View(plvm);
            }
                
            products = _productRepository.Products.Where(p => p.Category.Name.
            Equals(category)).
            OrderBy(p => p.Name).
            Select(item => new ProductDTO
            {
                ProductID = item.ProductID,
                Price = item.Price,
                Category = item.Category,
                Description = item.Description,
                ImageUrl = item.ImageUrl,
                IsPreferred = item.IsPreferred,
                Name = item.Name,
            }); ;

            var pvm = new ProductListViewModel
            {
                Products = products,
                CurrentCategory = category

            };

            return View(pvm);


        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetProductById(id); 

            //ProductDetailsDTO productDetailsDTO = new ProductDetailsDTO()
            //{
            //    ProductID = product.ProductID,
            //    Name = product.Name,
            //    Price = product.Price,
            //    Lenght = product.Lenght,
            //    Width = product.Width,
            //    Height = product.Height,
            //    Weight = product.Weight,
            //    Description = product.Description,
            //    Material = product.Material,
            //    Color = product.Color,
            //    IsPreferred = product.IsPreferred,
            //    ImageUrl = product.ImageUrl,
            //    Category = product.Category,
            //}/*;*/
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
