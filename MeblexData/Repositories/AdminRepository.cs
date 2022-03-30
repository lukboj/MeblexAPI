using MeblexData.Data;
using MeblexData.Interfaces;
using MeblexData.Models;
using MeblexData.Models.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace MeblexData.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Order> orders => _appDbContext.Orders.Include(a => a.OrderDetails).ThenInclude( a => a.Product);

        public IEnumerable<Product> products => _appDbContext.Products.Include(a => a.Category);

        public IEnumerable<Category> Categories => _appDbContext.Categories;

        public async Task<bool> AddCategoryAsync(Category category)
        {

            try
            {
                _appDbContext.Categories.Add(category);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<Product> AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteOrder(int? id)
        {
            var order = await _appDbContext.Orders.FindAsync(id);
            _appDbContext.Orders.Remove(order);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            //var order = await _appDbContext.Products.FindAsync(id);
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int? id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
        }


        public async Task<Product> EditProduct(Product product)
        {
            _appDbContext.Update(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _appDbContext.Orders.Include(a => a.OrderDetails).ThenInclude(a => a.Product).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
            return await _appDbContext.Categories.Include(a => a.Products).FirstOrDefaultAsync(a => a.CategoryId == id);
        }



        public async Task<Order> GetOrderByIdAsync(int? id)
        {
            return (await _appDbContext.Orders.FindAsync(id));
        }

        public async Task<Order> GetOrderDetails(int? id)
        {
            return (await _appDbContext.Orders
                .Include(a => a.OrderDetails)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id));
        }

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            return (await _appDbContext.Products.FirstOrDefaultAsync(a => a.ProductID == id));
        }

        public async Task<string> GetUserIdAsync(int id)
        {
            Order order = await _appDbContext.Orders.FindAsync(id);
            var obj = order.UserId;
            return obj;
        }

        public async Task<bool> IsShipped(int id)
        {
            Order order = await _appDbContext.Orders.FirstOrDefaultAsync(a => a.OrderId == id);
            if (order is null)
            {
                return false;
            }
            if (order.IsShipped == true)
            {
                return false;
            }
            try
            {
                order.IsShipped = true;
                _appDbContext.Update(order);
                await _appDbContext.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {

                throw;
            }
           

            return false;

        }

        public async Task UpdateProduct(Product product)
        {
            _appDbContext.Entry(product).State =  EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

        }

        public async Task UpdateCategory(Category category)
        {
            _appDbContext.Entry(category).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> ProductExist(int id)
        {
            return await _appDbContext.Products.AnyAsync(a => a.ProductID == id);
        }

        public async Task<bool> CategoryExist(int id)
        {
            return await _appDbContext.Categories.AnyAsync(a => a.CategoryId == id);

        }

        public async Task PrefferProduct(int id)
        {
            Product product = await _appDbContext.Products.FindAsync(id);

            if (product.IsPreferred.Equals(true))
            {
                product.IsPreferred = false;
                _appDbContext.Update(product);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                product.IsPreferred = true;
                _appDbContext.Update(product);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<Statistics> GetStatistics()
        {
            Statistics statistics = new Statistics
            {
                AmountOfMoneyEarned =  await _appDbContext.Orders.SumAsync(a => a.OrderTotal),
                AmountOfNotShippedOrders = await _appDbContext.Orders.CountAsync(a => a.IsShipped == false),
                AmountOfOrders = await _appDbContext.Orders.CountAsync(),
                AmountOfShippedOrders = await _appDbContext.Orders.CountAsync(a => a.IsShipped == true),
                AmountOfSoldMebels = await _appDbContext.OrdersDetails.SumAsync(a => a.Amount)
            };

            return (statistics);
        }

        public async Task<Category> GetCategoryDetailsAsync(int? id)
        {
            return (await _appDbContext.Categories.Include(a => a.Products).FirstOrDefaultAsync(a => a.CategoryId == id));
                
        }
    }
}
