using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        [Display(Name ="Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]

        public string LastName { get; set; }
        [Display(Name = "Miasto")]

        public string Town { get; set; }
        [Display(Name = "Kod Pocztowy")]

        public string ZipCode { get; set; }
        [Display(Name = "Adres")]

        public string AddresLine { get; set; }
        [Display(Name = "Numer Telefonu")]

        public string PhoneNumber { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool IsShipped { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
