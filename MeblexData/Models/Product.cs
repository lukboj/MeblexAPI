using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Lenght { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public bool IsPreferred { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnail { get; set; }
        public virtual Category Category { get; set; }
    }
}
