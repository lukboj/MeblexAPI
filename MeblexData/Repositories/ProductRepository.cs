using MeblexData.Data;
using MeblexData.Interfaces;
using MeblexData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Product> Products => _appDbContext.Products.Include(b => b.Category);

        public IEnumerable<Product> PreferredProducts => _appDbContext.Products.Where(p => p.IsPreferred).Include(c => c.Category);

        public Product GetProductById(int productid) => _appDbContext.Products.Find(productid);
        public async Task<Product> GetProductByIdAsync(int? id) => await _appDbContext.Products.FindAsync(id);



    }
}
