using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models.Order
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Ilość")]

        public int Amount { get; set; }
        [Display(Name = "Cena")]

        public decimal Price { get; set; }
        [Display(Name ="Mebel")]
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
