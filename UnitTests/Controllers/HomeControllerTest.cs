using AutoMapper;
using Meblex.Controllers;
using Meblex.ModelsDTO;
using Meblex.Services;
using MeblexData.Interfaces;
using MeblexData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly ProductService productService;

        private readonly Mock<IProductRepository> _productRepoMOck = new Mock<IProductRepository>();

        private static IMapper _mapper;


        public HomeControllerTest()
        {
            productService = new ProductService(_productRepoMOck.Object, _mapper);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(productService);
            // Act
            ViewResult result = controller.Privacy() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(productService);
            // Act
            ViewResult result = controller.About() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestProductDetails()
        {
            // Arrange
            HomeController controller = new HomeController(productService);

            var product = GetProduct();

            _productRepoMOck.Setup(x => x.GetProductByIdAsync(product.ProductID)).ReturnsAsync(GetProduct());

            var test = controller.Details(product.ProductID);
            Assert.IsNotNull(test);

        }

        ProductDetailsDTO GetProductDTO()
        {
            return new ProductDetailsDTO()
            {
                ProductID = 1,
                Name = "Meblościanka",
                Price = 2000,
                Description = "Super Meblościanka",
                IsPreferred = false,
                ImageUrl = "/imagines/stolik1.png",
                Category = new CategoryDTO()
                {
                    CategoryId = 1,
                    Description = "dasdadada",
                    Name = "Łóźko"

                },
            };
        }

        private async  Task<List<ProductDTO>> GetSampleProducts()
        {
            CategoryDTO category = new CategoryDTO
            {
                CategoryId = 1,
                Description = "Super",
                Name = "Łóxko",
            };

            List<ProductDTO> output = new List<ProductDTO>
            {
                new ProductDTO()
            {
                ProductID = 1,
                Name = "Meblościanka",
                Price = 2000,
                Description = "Super Meblościanka",
                IsPreferred = false,
                ImageUrl = "/imagines/stolik1.png",
                Category = category,
            },
                    new ProductDTO()
            {
                ProductID = 2,
                Name = "Meblościanka",
                Price = 1200,
                Description = "Super Meblościanka",
                IsPreferred = false,
                ImageUrl = "/imagines/stolik1.png",
                Category = category,
                    }
       
                };
            return output;
        }
        Product GetProduct()
        {
            return new Product()
            {
                ProductID = 1,
                Name = "Meblościanka",
                Price = 2000,
                Description = "Super Meblościanka",
                IsPreferred = false,
                ImageUrl = "/imagines/stolik1.png",
                Category = new Category()
                {
                    CategoryId = 1,
                    Description = "dasdadada",
                    Name = "Łóźko"

                }
            };
        }



    }
}