using Meblex.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meblex.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> createnewproduct(ProductDetailsDTO product);
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDetailsDTO> GetProductById(int? id);

        Task<bool> UpdateProduct(int productid, ProductDetailsDTO product);
        Task<bool> DeleteProduct(int productid);

        Task ChangePreffer(int id);

        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<OrderDetailsDTO> GetOrderById(int? id);

        Task<bool> OrderDone(int id);
        Task<bool> DeleteOrder(int order);

        Task<bool> CreateNewCategory(CategoryDetailsDTO category);
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDetailsDTO> GetCategoryById(int? id);

        Task<bool> UpdateCategory(int categoryid, CategoryDetailsDTO product);
        Task<bool> DeleteCategory(int categoryid);

        Task<bool> CategoryExist(int id);
        Task<bool> ProductExist(int id);

        Task<StatisticsDTO> GetStatistics();



    }
}
