using MeblexData.Models;
using System.ComponentModel.DataAnnotations;

namespace Meblex.ModelsDTO
{
    public class ProductDTO
    {
        [Display(Name="ID")]
        public int ProductID { get; set; }
        [Display(Name = "Nazwa")]

        public string Name { get; set; }
        [Display(Name = "Cena")]

        public decimal Price { get; set; }
        [Display(Name = "Opis")]

        public string Description { get; set; }
        [Display(Name = "Promowanie")]

        public bool IsPreferred { get; set; } = false;
        [Display(Name = "Zródła Obrazka")]

        public string ImageUrl { get; set; }
        [Display(Name = "Kategoria")]

        public virtual CategoryDTO Category { get; set; }
    }
}
