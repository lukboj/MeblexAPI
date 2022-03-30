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

        public async Task<List<Category>> Categories()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public IEnumerable<Product> PreferredProducts => _appDbContext.Products.Where(p => p.IsPreferred).Include(c => c.Category);


        public async Task<Product> GetProductById(int productid) => await _appDbContext.Products.FindAsync(productid);
        public async Task<Product> GetProductByIdAsync(int? id) => await _appDbContext.Products.FindAsync(id);

        public async Task<List<Product>> GetPrefferedProducts()
        {
            return await _appDbContext.Products.Where(a => a.IsPreferred == true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts() => await _appDbContext.Products.OrderBy(a => a.ProductID).ToListAsync();


        public async Task<IEnumerable<Product>> GetProductsByCategory(string name) => await _appDbContext.Products.Include(a => a.Category)
            .Where(a => a.Category.Name == name).OrderBy(a => a.Name).ToListAsync();

        public Product Gp(int? id)
        {
            return _appDbContext.Products.Find(id);
        }
    }
}
