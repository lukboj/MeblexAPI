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
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    [TestClass]

    public class AdminServiceTests
    {
        private readonly AdminService adminService;

        private readonly Mock<IAdminRepository> adminmock = new Mock<IAdminRepository>();

        private static IMapper _mapper;

        [TestMethod]
        public async Task GetProducts_withoutfail_withList()
        {
            // Arrange
            AdminController controller = new AdminController(adminService);

            var list = GetProducts();


            adminmock.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(GetProducts());

            var testlist = controller.Products();

            Assert.IsNotNull(testlist);
        }

        [TestMethod]
        public async Task TestProductsList()
        {
            // Arrange
            AdminController controller = new AdminController(adminService);

            var list = GetProducts();


            adminmock.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(GetProducts());

            var testlist = controller.Products();

            Assert.IsNotNull(testlist);
        }

        [TestMethod]
        public async Task TestProductDetails()
        {
            // Arrange
            AdminController controller = new AdminController(adminService);

            var product = GetProduct();

            adminmock.Setup(x => x.GetProductByIdAsync(product.ProductID)).ReturnsAsync(GetProduct());

            var test = controller.DetailsProduct(product.ProductID);
            Assert.IsNotNull(test);
            
        }

        [TestMethod]
        public async Task TestProductDelete()
        {
            // Arrange
            AdminController controller = new AdminController(adminService);

            var product = GetProduct();

            adminmock.Setup(x => x.GetProductByIdAsync(product.ProductID)).ReturnsAsync(GetProduct());

            var test = controller.DeleteProduct(product.ProductID);
            Assert.IsNotNull(test);

        }

        [TestMethod]
        public async Task TestProductCreationWithoutFail()
        {
            // Arrange
            AdminController controller = new AdminController(adminService);

            var product = GetProductDTO();
            var product1 = GetProduct();


            adminmock.Setup(x => x.AddProduct(product1)).ReturnsAsync(GetProduct());

            var test = controller.CreateProduct(product);

            Assert.IsNotNull(test);
            Assert.AreEqual(product1.ProductID, product.ProductID);

        }

        [TestMethod]

        public async Task getCategories_withoutfail()
        {
            AdminController controller = new AdminController(adminService);

            var categories = GetCategories();

            adminmock.Setup(x => x.GetAllCategoriesAsync()).ReturnsAsync(categories);

            var test = controller.Categories();

            Assert.IsNotNull(test);

        }

        [TestMethod]
        public async Task GetCategoriesDetail_withoutFail()
        {
            // Arrange
            AdminController controller = new AdminController(adminService);

            var category = GetCategory();

            adminmock.Setup(x => x.GetCategoryByIdAsync(category.CategoryId)).ReturnsAsync(category);

            var test = controller.DetailsCategory(category.CategoryId);

            Assert.IsNotNull(test);


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

        List<Product> GetProducts()
        {
            return new List<Product>()
            { new Product()
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

                },
            },
            new Product()
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

                },
            }

        };

        }

        Category GetCategory()
        {
            return new Category()
            {
                CategoryId = 1,
                Description = "bla bla",
                Name = "Kapcie",
                Products = GetProducts()
            };
        }
        List<Category> GetCategories()
        {
            return new List<Category>()
            { new Category()
            {
                CategoryId = 1,
                Description= "bla bla",
                Name="Kapcie",
                Products= GetProducts()
            },
            new Category()
            {
                CategoryId = 2,
                Description= "bla bla",
                Name="Kapcie",
                Products= GetProducts()
            }
            };
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
        List<ProductDetailsDTO> GetProductsDTO()
        {
            return new List<ProductDetailsDTO>()
            { new ProductDetailsDTO()
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
            },
            new ProductDetailsDTO()
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
            }

        };

            List<Product> GetProducts()
            {
                return new List<Product>()
            { new Product()
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

                },
            },
            new Product()
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

                },
            }

        };

            }
        }
    }
}

