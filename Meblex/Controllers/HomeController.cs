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
                PrefferedProducts = _productRepository.PreferredProducts
            };

            return View(homeviewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
