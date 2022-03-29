//using Autofac.Extras.Moq;
//using Meblex.Controllers;
//using Meblex.ModelsDTO;
//using MeblexData.Interfaces;
//using MeblexData.Models;
//using MeblexData.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

//namespace UnitTests
//{
//    public class UserServiceTest

//    {
//        [TestMethod]
//        public async void Add_AddingItemToEmptyCart_CountShouldBeOne()
//        {
//            //var mockAdminRepository = new Mock<IAdminRepository>();
//            //Product product = new Product()
//            //{
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



        //}
        //[Fact]
        //public async Task Index_ReturnsAViewResult_WithAListOfOrderDTO()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IAdminRepository>();
        //    mockRepo.Setup(repo => repo.GetAllProductsAsync())
        //        .ReturnsAsync(GetSampleProducts());

        //    var controller = new AdminController(mockRepo.Object);

        //    // Act
        //    var result =  controller.Products();

        //    // Assert
        //    var viewResult = Assert.IsInstanceOfType<ViewResult>(result);

        //    var model = Assert.IsInstanceOfType<IEnumerable<IAdminRepository>>(
        //        viewResult.ViewData.Model);
        //    Assert.Equals(2, model.Count());
        //}

        //[Fact]

        //public async void LoadProducts_validCall()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        mock.Mock<IAdminRepository>()
        //            .Setup(x => x.GetAllProductsAsync())
        //            .ReturnsAsync(GetSampleProducts());

        //        var cls = mock.Create<AdminRepository>();

        //        var expected = GetSampleProducts();

        //        var actual = await cls.GetAllProductsAsync();

        //        Assert.IsTrue(actual != null);
        //        Assert.Equals(expected.Count, actual.Count());
        //    };
        //}
        //private List<ProductDTO> GetSampleProducts()
        //{
        //    Category category = new Category
        //    {
        //        CategoryId = 1,
        //        Description = "Super",
        //        Name = "Łóxko",
        //    };

        //    List<ProductDTO> output = new List<ProductDTO>
        //    {
        //        new ProductDTO()
        //    {
        //        ProductID = 1,
        //        Name = "Meblościanka",
        //        Price = 2000,
        //        Description = "Super Meblościanka",
        //        IsPreferred = false,
        //        ImageUrl = "/imagines/stolik1.png",
        //        Category = category,
        //    },
        //            new ProductDTO()
        //    {
        //        ProductID = 2,
        //        Name = "Meblościanka",
        //        Price = 1200,
        //        Description = "Super Meblościanka",
        //        IsPreferred = false,
        //        ImageUrl = "/imagines/stolik1.png",
        //        Category = category,

        //    },
            //            new Product()
            //{
            //    ProductID = 3,
            //    Name = "Meblościanka",
            //    Price = 2500,
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
            //},
            //                new Product()
            //{
            //    ProductID = 4,
            //    Name = "Meblościanka",
            //    Price = 1500,
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
            //},
            //                    new Product()
            //{
            //    ProductID = 5,
            //    Name = "Meblościanka",
            //    Price = 500,
            //    Lenght = 50,
//            //    Width = 50,
//            //    Height = 50,
//            //    Weight = 50,
//            //    Description = "Super Meblościanka",
//            //    Material = "Drewno",
//            //    Color = "Czarny",
//            //    IsPreferred = false,
//            //    ImageUrl = "/imagines/stolik1.png",
//            //    CategoryID = 3,
//            //}


//        };


//            return output;
//        }

//    }
//}
