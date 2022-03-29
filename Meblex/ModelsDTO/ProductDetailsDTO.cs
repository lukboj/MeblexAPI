using MeblexData.Models;
using System.ComponentModel.DataAnnotations;

namespace Meblex.ModelsDTO
{
    public class ProductDetailsDTO
    {
        [Display(Name = "ID")]

        public int ProductID { get; set; }
        [Display(Name="Nazwa")]

        public string Name { get; set; }
        [Display(Name = "Nazwa")]

        public decimal Price { get; set; }
        [Display(Name = "Wysokość")]

        public int Lenght { get; set; }
        [Display(Name = "Szerokość")]

        public int Width { get; set; }
        [Display(Name = "Wysokość (CM)")]

        public int Height { get; set; }
        [Display(Name = "Waga (KG)")]

        public decimal Weight { get; set; }
        [Display(Name = "Opis")]

        public string Description { get; set; }
        [Display(Name = "Materiał")]

        public string Material { get; set; }
        [Display(Name = "Kolor")]
        public string Color { get; set; }
        [Display(Name = "Promowanie")]

        public bool IsPreferred { get; set; }
        [Display(Name = "Źródła obrazka")]

        public string ImageUrl { get; set; }
        [Display(Name = "Kategoria")]

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
