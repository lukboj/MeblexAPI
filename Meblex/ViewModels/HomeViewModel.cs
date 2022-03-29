using Meblex.ModelsDTO;
using MeblexData.Models;
using System.Collections.Generic;

namespace Meblex.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ProductDTO> PrefferedProducts { get; set; }
    }
}
