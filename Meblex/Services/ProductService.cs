using AutoMapper;
using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MeblexData.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meblex.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository _productRepository, IMapper _autoMapper)
        {
            productRepository = _productRepository;
            mapper = _autoMapper;
        
        }
        public async Task<List<CategoryDTO>> GetCategories()
        {
            var list = await productRepository.Categories();
            var listdto = mapper.Map<List<CategoryDTO>>(list);
            return listdto;
        }

        public Task<CategoryDetailsDTO> GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProductDTO>> GetPrefferedProducts()
        {
            var list = await productRepository.GetPrefferedProducts();
            var listdto = mapper.Map<List<ProductDTO>>(list);
            return listdto;
        }


        public async Task<ProductDetailsDTO> GetProductById(int? id)
        {
            var product = await productRepository.GetProductByIdAsync(id);

            var prodctdto = mapper.Map<ProductDetailsDTO>(product);

            return prodctdto;
        }

        public Task<List<ProductDTO>> GetProducts()
        {
            throw new System.NotImplementedException();
        }


    }
}
