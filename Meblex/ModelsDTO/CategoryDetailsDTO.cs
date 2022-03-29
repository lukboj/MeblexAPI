using MeblexData.Models;
using System.Collections.Generic;

namespace Meblex.ModelsDTO
{
    public class CategoryDetailsDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> products { get; set; }

    }
}
