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
        [Required(ErrorMessage = "Prosze podać swoje imię")]
        [StringLength(50)]

        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Prosze podać swoje nazwisko")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Prosze wprowadzić nazwe miasta")]
        [StringLength(50)]
        public string Town { get; set; }
        [Display(Name = "Kod Pocztowy")]
        [Required(ErrorMessage = "Prosze Podać Kod pocztowy")]
        [StringLength(50)]
        public string ZipCode { get; set; }
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Prosze wprowadzić nazwe ulicy i numer domu")]
        [StringLength(50)]
        public string AddresLine { get; set; }
        [Display(Name = "Numer Telefonu")]
        [Required(ErrorMessage = "Prosze Podać Numer telefonu")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Wartość zamówienia")]

        public decimal OrderTotal { get; set; }
        [Display(Name = "Data Zamówienia")]

        public DateTime OrderPlaced { get; set; }
        [Display(Name = "Status")]

        public bool IsShipped { get; set; } = false;
        public List<OrderDetail> OrderDetails { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
