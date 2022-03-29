using System;
using System.ComponentModel.DataAnnotations;

namespace Meblex.ModelsDTO
{
    public class OrderDTO
    {
        [Display(Name="ID")]
        public int OrderId { get; set; }
        [Display(Name = "Nazwisko")]

        public string LastName { get; set; }
        [Display(Name = "Numer Telefonu")]

        public string PhoneNumber { get; set; }
        [Display(Name = "Wartość Zamówienia")]

        public decimal OrderTotal { get; set; }
        [Display(Name = "Data Zamówienia")]

        public DateTime OrderPlaced { get; set; }
        [Display(Name = "Status")]

        public bool IsShipped { get; set; } 
    }
}
