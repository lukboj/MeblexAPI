using Meblex.ModelsDTO;
using System.Collections.Generic;

namespace Meblex.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}
