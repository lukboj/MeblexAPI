using Meblex.ModelsDTO;
using Meblex.ViewModels;
using MeblexData.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Meblex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index()
        {
            var homeviewmodel = new HomeViewModel
            {
                PrefferedProducts = _productRepository.PreferredProducts.Select(item => new ProductDTO
                {
                    ProductID = item.ProductID,
                    Name = item.Name,
                    Price = item.Price,
                    IsPreferred = item.IsPreferred,
                    Category = item.Category,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,

                }
            )
            };
        

            return View(homeviewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductByIdAsync(id);

            ProductDetailsDTO productDetailsDTO = new ProductDetailsDTO()
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Price = product.Price,
                Lenght = product.Lenght,
                Width = product.Width,
                Height = product.Height,
                Weight = product.Weight,
                Description = product.Description,
                Material = product.Material,
                Color = product.Color,
                IsPreferred = product.IsPreferred,
                ImageUrl = product.ImageUrl,
                Category = product.Category,
            };

            if (productDetailsDTO == null)
            {
                return NotFound();
            }

            return View(productDetailsDTO);
        }


    }
}
