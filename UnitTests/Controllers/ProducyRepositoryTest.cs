using Meblex.Controllers;
using MeblexData.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTests.Controllers
{
    public class ProducyRepositoryTest
    {
        private readonly ProductController productController;
        private readonly Mock<IProductRepository> productrepo = new Mock<IProductRepository>();

        public ProducyRepositoryTest()
        {
            productController = new ProductController(productrepo.Object);
        }



        [TestMethod]
        public void IndexView()
        {
            //var empcontroller = productController(new IProductRepository());
            //ViewResult result = empcontroller.Index();
            //Assert.AreEqual("Index", result.ViewName);
        }
    }
}
