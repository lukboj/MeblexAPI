using MeblexData.Models;
using MeblexData.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        IEnumerable<Order> orders { get; }

        IEnumerable<Product> products { get; }

        IEnumerable<Category> Categories { get; }
        Task<Product> AddProduct(Product product);

        Task<Category> AddCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int? id);

        Task<Order> GetOrderByIdAsync(int? id);

        Task<Product> GetProductByIdAsync(int? id);

        Task<String> GetUserIdAsync(int id);

        Task<Order> GetOrderDetails(int? id);

        Task<Category> GetCategoryDetailsAsync(int? id);

        Task UpdateProduct(Product product);

        Task UpdateCategory(Category category);

        Task DeleteProduct(int? id);
        Task DeleteOrder(int? id);
        Task DeleteCategoryAsync(int? id);

        Task<Product> EditProduct(Product product);

        Task<Order> IsShipped(int id);

        Task PrefferProduct(int id);

        Task<bool> ProductExist(int id);

        Task<bool> CategoryExist(int id);

        Statistics GetStatistics();



        
    }
}
