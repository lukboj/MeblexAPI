using MeblexData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get;  }
        IEnumerable<Product> PreferredProducts { get; }
        Task<Product> GetProductById(int id);

        Task<List<Category>> Categories();

        Task<Product> GetProductByIdAsync(int? productid);

        Task<List<Product>> GetPrefferedProducts();
    }
}
