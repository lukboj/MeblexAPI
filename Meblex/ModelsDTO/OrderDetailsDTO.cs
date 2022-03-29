using MeblexData.Models;
using MeblexData.Models.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meblex.ModelsDTO
{
    public class OrderDetailsDTO
    {

        public int OrderId { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Imię")]


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
