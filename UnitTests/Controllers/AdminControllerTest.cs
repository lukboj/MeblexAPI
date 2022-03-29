//using Meblex.Controllers;
//using Meblex.ModelsDTO;
//using MeblexData.Interfaces;
//using MeblexData.Models;
//using MeblexData.Models.Order;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//using Xunit;

//namespace UnitTests.Controllers
//{
//    public class AdminControllerTest
//    {
//        private readonly AdminController adminController;
//        private readonly Mock<IAdminRepository> adminrepo = new Mock<IAdminRepository>();

//        public AdminControllerTest()
//        {
//            adminController = new AdminController(adminrepo.Object);
//        }

//        [Fact]
//        public void Index_ReturnsAViewResult_WithAListOfEmployees()
//        {
//            // Arrange
//            var mockRepo = new Mock<IAdminRepository>();

//            mockRepo.Setup(repo => repo.GetAllOrdersAsync())
//                .Returns(GetTestOrders());
//            var controller = new AdminController(mockRepo.Object);
//            // Act
//            var result = controller.Index();
//            // Assert
//            var viewResult = Assert.ix<ViewResult>(result);
//            var model = Assert.IsAssignableFrom<List<Order>>(
//                viewResult.ViewData.Model);
//            Assert.Equals(2, model.Count());
//        }

//        [Fact]
//        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
//        {
//            // Arrange
//            var mockRepo = new Mock<IAdminRepository<Order>>();
//            var controller = new AdminController(mockRepo.Object);
//            controller.ModelState.AddModelError("Name", "Required");
//            var newEmployee = GetTestOrders();
//            // Act
//            var result = controller.add(newEmployee);
//            // Assert
//            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//            Assert.IsType<SerializableError>(badRequestResult.Value);
//        }
//        private IEnumerable<OrderDTO> GetTestOrders()
//        {
//            return new List<OrderDTO>()
//    {
//        new OrderDTO()
//        {
//            OrderId = 1,
//            LastName= "Borek"
//        },
//        new OrderDTO()
//        {
//            OrderId = 2,
//            LastName= "Maniek"
//        }
//    };
//        }

//        [TestMethod]
//        public void IndexView()
//        {
//            var empcontroller = adminController(new adminrepo());
//            ViewResult result = empcontroller.Index();
//            Assert.AreEqual("Index", result.ViewName);
//        }

//        [Fact]
//        public async Task GetProductById_ShouldReturnProduct_WhenProductExist()
//        {
//            //Arange
//            public IEnumerable<Product> products;
       

            
            

//            Product p = new Product()
//            {
//                ProductID = 1,
//                Name = "Meblościanka",
//                Price = 2500,
//                Lenght = 50,
//                Width = 50,
//                Height = 50,
//                Weight = 50,
//                Description = "Super Meblościanka",
//                Material = "Drewno",
//                Color = "Czarny",
//                IsPreferred = false,
//                ImageUrl = "/imagines/stolik1.png",
//                CategoryID = 3,
//            };

//            Product p2 = new Product()
//            {
//                ProductID = 2,
//                Name = "Meblościanka",
//                Price = 2500,
//                Lenght = 50,
//                Width = 50,
//                Height = 50,
//                Weight = 50,
//                Description = "Super Meblościanka",
//                Material = "Drewno",
//                Color = "Czarny",
//                IsPreferred = false,
//                ImageUrl = "/imagines/stolik1.png",
//                CategoryID = 3,
//            };

            
            

//        //    List<Product> output = new List<Product>
//        //    {
//        //               new Product()
//        //{
//        //    ProductID = 1,
//        //    Name = "Meblościanka",
//        //    Price = 2500,
//        //    Lenght = 50,
//        //    Width = 50,
//        //    Height = 50,
//        //    Weight = 50,
//        //    Description = "Super Meblościanka",
//        //    Material = "Drewno",
//        //    Color = "Czarny",
//        //    IsPreferred = false,
//        //    ImageUrl = "/imagines/stolik1.png",
//        //    CategoryID = 3,
//        //},
//        //               new Product()
//        //{
//        //    ProductID = 2,
//        //    Name = "Meblościanka",
//        //    Price = 2500,
//        //    Lenght = 50,
//        //    Width = 50,
//        //    Height = 50,
//        //    Weight = 50,
//        //    Description = "Super Meblościanka",
//        //    Material = "Drewno",
//        //    Color = "Czarny",
//        //    IsPreferred = false,
//        //    ImageUrl = "/imagines/stolik1.png",
//        //    CategoryID = 3,
//        //},
//        //            new Product()
//        //{
//        //    ProductID = 3,
//        //    Name = "Meblościanka",
//        //    Price = 2500,
//        //    Lenght = 50,
//        //    Width = 50,
//        //    Height = 50,
//        //    Weight = 50,
//        //    Description = "Super Meblościanka",
//        //    Material = "Drewno",
//        //    Color = "Czarny",
//        //    IsPreferred = false,
//        //    ImageUrl = "/imagines/stolik1.png",
//        //    CategoryID = 3,
//        //},
//        //                new Product()
//        //{
//        //    ProductID = 4,
//        //    Name = "Meblościanka",
//        //    Price = 1500,
//        //    Lenght = 50,
//        //    Width = 50,
//        //    Height = 50,
//        //    Weight = 50,
//        //    Description = "Super Meblościanka",
//        //    Material = "Drewno",
//        //    Color = "Czarny",
//        //    IsPreferred = false,
//        //    ImageUrl = "/imagines/stolik1.png",
//        //    CategoryID = 3,
//        //},
//        //                    new Product()
//        //{
//        //    ProductID = 5,
//        //    Name = "Meblościanka",
//        //    Price = 500,
//        //    Lenght = 50,
//        //                Width = 50,
//        //                Height = 50,
//        //                Weight = 50,
//        //                Description = "Super Meblościanka",
//        //                Material = "Drewno",
//        //                Color = "Czarny",
//        //                IsPreferred = false,
//        //                ImageUrl = "/imagines/stolik1.png",
//        //                CategoryID = 3,
//        //            } };



//            adminrepo.Setup(a => a.GetAllProductsAsync())
//              .ReturnsAsync(output);

//            var list = adminController.Products();
//            //assert
//            //Assert.AreEqual(output[0], list[0]);

//        }

//        private List<Product> GetSampleProducts()
//        {


//            List<Product> output = new List<Product>
//            {
//                       new Product()
//        {
//            ProductID = 1,
//            Name = "Meblościanka",
//            Price = 2500,
//            Lenght = 50,
//            Width = 50,
//            Height = 50,
//            Weight = 50,
//            Description = "Super Meblościanka",
//            Material = "Drewno",
//            Color = "Czarny",
//            IsPreferred = false,
//            ImageUrl = "/imagines/stolik1.png",
//            CategoryID = 3,
//        },
//                       new Product()
//        {
//            ProductID = 2,
//            Name = "Meblościanka",
//            Price = 2500,
//            Lenght = 50,
//            Width = 50,
//            Height = 50,
//            Weight = 50,
//            Description = "Super Meblościanka",
//            Material = "Drewno",
//            Color = "Czarny",
//            IsPreferred = false,
//            ImageUrl = "/imagines/stolik1.png",
//            CategoryID = 3,
//        },
//                    new Product()
//        {
//            ProductID = 3,
//            Name = "Meblościanka",
//            Price = 2500,
//            Lenght = 50,
//            Width = 50,
//            Height = 50,
//            Weight = 50,
//            Description = "Super Meblościanka",
//            Material = "Drewno",
//            Color = "Czarny",
//            IsPreferred = false,
//            ImageUrl = "/imagines/stolik1.png",
//            CategoryID = 3,
//        },
//                        new Product()
//        {
//            ProductID = 4,
//            Name = "Meblościanka",
//            Price = 1500,
//            Lenght = 50,
//            Width = 50,
//            Height = 50,
//            Weight = 50,
//            Description = "Super Meblościanka",
//            Material = "Drewno",
//            Color = "Czarny",
//            IsPreferred = false,
//            ImageUrl = "/imagines/stolik1.png",
//            CategoryID = 3,
//        },
//                            new Product()
//        {
//            ProductID = 5,
//            Name = "Meblościanka",
//            Price = 500,
//            Lenght = 50,
//                        Width = 50,
//                        Height = 50,
//                        Weight = 50,
//                        Description = "Super Meblościanka",
//                        Material = "Drewno",
//                        Color = "Czarny",
//                        IsPreferred = false,
//                        ImageUrl = "/imagines/stolik1.png",
//                        CategoryID = 3,
//                    } };
//            return (output);
//        }
//    }
//}

//Category category = new Category
//{
//    CategoryId = 1,
//    Description = "Super",
//    Name = "Łóxko",
//};

//Product product = new Product()
//{
//    ProductID = 3,
//    Name = "Meblościanka",
//    Price = -500,
//    Lenght = 50,
//    Width = 50,
//    Height = 50,
//    Weight = 50,
//    Description = "Super Meblościanka",
//    Material = "Drewno",
//    Color = "Czarny",
//    IsPreferred = false,
//    ImageUrl = "/imagines/stolik1.png",
//    CategoryID = 3,
//};




//ProductDTO productdto = new ProductDTO()
//{
//    ProductID = 1,
//    Name = "Meblościanka",
//    Price = 2000,
//    Description = "Super Meblościanka",
//    IsPreferred = false,
//    ImageUrl = "/imagines/stolik1.png",
//    Category = category,
//};
