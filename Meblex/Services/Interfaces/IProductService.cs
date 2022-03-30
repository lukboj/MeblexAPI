using Meblex.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meblex.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<CategoryDTO>> GetCategories();
        Task<List<ProductDTO>> GetProducts();

        Task<ProductDetailsDTO> GetProductById(int? id);

        Task<CategoryDetailsDTO> GetCategory(int id);

        Task<List<ProductDTO>> GetPrefferedProducts();
            


    }
}
