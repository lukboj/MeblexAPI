using Meblex.ViewModels;
using MeblexData.Interfaces;
using MeblexData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Meblex.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }


        public ViewResult List(string? category)
        {
            string _category = category;
            IEnumerable<Product> products;

            string currentcategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
              
                products = _productRepository.Products.OrderBy(p => p.ProductID);
                currentcategory = "Wszystkie produkty";

                var plvm = new ProductListViewModel
                {
                    Products = products,
                    CurrentCategory = currentcategory

                };
                return View(plvm);
            }
                
            products = _productRepository.Products.Where(p => p.Category.Name.Equals(category)).OrderBy(p => p.Name);

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
    }
}
