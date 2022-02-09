using MeblexData.Models;
using System.Collections.Generic;

namespace Meblex.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}
