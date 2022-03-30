using Meblex.ModelsDTO;
using MeblexData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meblex.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<CategoryDTO>> GetCategories();
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<IEnumerable<ProductDTO>> GetProductsByCategoryId(string name);


        Task<ProductDetailsDTO> GetProductById(int? id);

        Task<CategoryDetailsDTO> GetCategory(int id);

        Task<List<ProductDTO>> GetPrefferedProducts();
        Product GetProductByIdNotAsync(int? id);

 


    }
}
