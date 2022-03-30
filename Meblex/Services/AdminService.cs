using AutoMapper;
using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MeblexData.Interfaces;
using MeblexData.Models;
using MeblexData.Models.Order;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meblex.Services
{
    public class AdminService : IAdminService
    {
        private IAdminRepository adminRepository;
        private readonly IMapper mapper;
        public AdminService(IAdminRepository _adminRepository, IMapper _mapper)
        {
            adminRepository = _adminRepository;
            mapper = _mapper;
        }

        public async Task<bool> createnewproduct(ProductDetailsDTO product)
        {
            if (product != null)
            {
                var newproduct = mapper.Map<Product>(product);

                var result = await adminRepository.AddProduct(newproduct);

                return true;
            }
            return false;

        }

        public async Task<bool> DeleteProduct(int productid)
        {
            if (productid > 0)
            {
                var product = await adminRepository.GetProductByIdAsync(productid);
                if (product != null)
                {
                    await adminRepository.DeleteProduct(product);
                    return true;

                }

            }
            return false;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var list = await adminRepository.GetAllProductsAsync();
            var listdto = mapper.Map<IEnumerable<ProductDTO>>(list);
           
            return listdto;
        }

        public async Task<ProductDetailsDTO> GetProductById(int? id)
        {
            if (id > 0)
            {
                var product = await adminRepository.GetProductByIdAsync(id);
                if (product != null)
                {
                    var productDTO = mapper.Map<ProductDetailsDTO>(product);
                    return productDTO;

                }

            }
            return null;
        }

        public async Task<bool> UpdateProduct(int productid, ProductDetailsDTO productDetailsDTO)
        {
            if (productid > 0)
            {
                var product = mapper.Map<Product>(productDetailsDTO);

                if (product != null)
                {
                    await adminRepository.UpdateProduct(product);
                    return true;

                }

            }
            return false;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            var list = await adminRepository.GetAllOrdersAsync();
            var listdto = mapper.Map<IEnumerable<OrderDTO>>(list);

            return listdto;
        }

        public async Task<OrderDetailsDTO> GetOrderById(int? id)
        {
            if (id > 0)
            {
                var order = await adminRepository.GetOrderDetails(id);
                if (order != null)
                {
                    var orderdto = mapper.Map<OrderDetailsDTO>(order);
                    
                    return orderdto;
                    
                }

            }
            return null;
        }

        public Task<bool> OrderDone(int id)
        {
           return adminRepository.IsShipped(id);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            if(id < 0)
            {
                return false;
            }

            var order = await adminRepository.GetOrderByIdAsync(id);

            if (order != null)
            {
                return false;
            }
            try
            {
                await adminRepository.DeleteOrder(id);
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Task ChangePreffer(int id)
        {
          return  adminRepository.PrefferProduct(id);
        }

        public Task<bool> CreateNewCategory(CategoryDetailsDTO category)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var list = await adminRepository.GetAllCategoriesAsync();
            var listdto = mapper.Map<IEnumerable<CategoryDTO>>(list);

            return listdto;
        }

        public async Task<CategoryDetailsDTO> GetCategoryById(int? id)
        {
            if (id > 0)
            {
                var category = await adminRepository.GetCategoryByIdAsync(id);

                if (category != null)
                {
                    var categorydto = mapper.Map<CategoryDetailsDTO>(category);

                    return categorydto;

                }

            }
            return null;
        }

        public async Task<bool> UpdateCategory(int categoryid, CategoryDetailsDTO categoryDetailsDTO)
        {
            if (categoryid > 0)
            {
                var category = mapper.Map<Category>(categoryDetailsDTO);

                if (category != null)
                {
                    await adminRepository.UpdateCategory(category);
                    return true;

                }

            }
            return false;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            if (id < 0)
            {
                return false;
            }

            var category = await adminRepository.GetCategoryByIdAsync(id);

            if (category != null)
            {
                return false;
            }
            try
            {

                await adminRepository.DeleteCategoryAsync(id);
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Task<bool> CategoryExist(int id)
        {
           return adminRepository.CategoryExist(id);
        }

        public Task<bool> ProductExist(int id)
        {
            return adminRepository.ProductExist(id);

        }

        public async Task<StatisticsDTO> GetStatistics()
        {
           var stat = await  adminRepository.GetStatistics();
           var statdto = mapper.Map<StatisticsDTO>(stat);
           return statdto;
        }
    }
}
