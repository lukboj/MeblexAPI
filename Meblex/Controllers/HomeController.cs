using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
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
        private readonly IProductService productService;
        public HomeController(IProductService _productService)
        {
            productService = _productService;

        }

        public async Task<ViewResult> Index()
        {
            var list = await productService.GetPrefferedProducts();
            HomeViewModel hvm = new HomeViewModel(list);
            
            return View(hvm);
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

            var product = await productService.GetProductById(id);


            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


    }
}
