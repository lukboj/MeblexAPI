using MeblexData.Models;
using MeblexData.Models.Order;
using System.ComponentModel.DataAnnotations;

namespace Meblex.ModelsDTO
{
    public class OrderListDTO
    {
        public int OrderDetailId { get; set; }
        [Display(Name ="Ilość")]
        public int Amount { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
        public virtual ProductDTO Product { get; set; }
        public virtual OrderDTO Order { get; set; }
    }
}
