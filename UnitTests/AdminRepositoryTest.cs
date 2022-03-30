using MeblexData.Data;
using MeblexData.Models;
using MeblexData.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class AdminRepositoryTest
    {
        //public void GetProductByIdAsync_Returns_Product()
        //{
        //    //Setup DbContext and DbSet mock  
        //    var dbContextMock = new Mock<AppDbContext>();
        //    var dbSetMock = new Mock<DbSet<Product>>();

        //    dbSetMock.Setup(s => s.FindAsync(It.IsAny<int>())).Returns(ValueTask<Product> Product);
        //    dbContextMock.Setup(s => s.Set<Product>()).Returns(dbSetMock.Object);

        //    //Execute method of SUT (ProductsRepository)  
        //    var productRepository = new AdminRepository(dbContextMock.Object);
        //    var product = productRepository.GetProductByIdAsync(int).Result;

        //    //Assert  
        //    Assert.IsNotNull(product);
        //    Assert.IsInstanceOfType(product, typeof(Product));
        //}

        //[Fact]
        //public async Task GetByIdAsync_Throws_NotFoundException()
        //{
        //    var dbContextMock = new Mock<AppDbContext>();

        //    var dbSetMock = new Mock<DbSet<Product>>();
        //    dbSetMock.Setup(s => s.FindAsync(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

        //    dbContextMock.Setup(s => s.Set<Product>()).Returns(dbSetMock.Object);
        //    var productRepository = new AdminRepository(dbContextMock.Object);

        //    var product = await productRepository.GetProductByIdAsync(id);
        //    Assert.IsNull(product);

        //}

        [Fact]

        public void ExecuteShouldReturnCorrectType()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
        }
    }
}
