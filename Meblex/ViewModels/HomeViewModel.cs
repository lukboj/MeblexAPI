using Meblex.ModelsDTO;
using MeblexData.Models;
using System.Collections.Generic;

namespace Meblex.ViewModels
{
    public class HomeViewModel
    {
        public  HomeViewModel() { }

        public HomeViewModel(List<ProductDTO> productDTOs)
        {
            PrefferedProducts = productDTOs;
        }
        public IEnumerable<ProductDTO> PrefferedProducts { get; set; }
    }
}
