using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models
{
    public class Product
    {
        [Key]
        [Display(Name="ID")]
        public int ProductID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Prosze podać nazwe")]
        public string Name { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Prosze podać cene")]
        [DataType(DataType.Currency)]
        [Range(0, 10000)]
        [Column(TypeName = "decimal(18, 2)")]

        public decimal Price { get; set; }
        [Display(Name = "Długość (CM)")]
        [Required(ErrorMessage = "Prosze podać długość")]
        [Range(0, 3000)]

        public int Lenght { get; set; }
        [Display(Name = "Szerokość (CM)")]
        [Required(ErrorMessage = "Prosze podać szerokość")]
        [Range(0, 3000)]

        public int Width { get; set; }
        [Display(Name = "Wysokość (CM)")]
        [Required(ErrorMessage = "Prosze podać wysokość")]
        [Range(0, 3000)]

        public int Height { get; set; }
        [Display(Name = "Waga (KG)")]
        [Required(ErrorMessage = "Prosze podać wage")]
        [Range(0, 3000)]

        public decimal Weight { get; set; }
        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Prosze podać opis")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Minimalna ilość znaków to 3 a maksymalna 60")]

        public string Description { get; set; }
        [Display(Name = "Materiał")]
        [Required(ErrorMessage = "Prosze podać materiał")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Minimalna ilość znaków to 3 a maksymalna 60")]

        public string Material { get; set; }
        [Display(Name = "Kolor")]
        [Required(ErrorMessage = "Prosze podać kolor")]
        [StringLength(60, MinimumLength = 3)]

        public string Color { get; set; }
        [Display(Name = "Promowanie")]

        public bool IsPreferred { get; set; } = false;
        [Display(Name ="Kod Obrazka")]
        [Required(ErrorMessage = "Prosze podać cene")]
        public string ImageUrl { get; set; }
        [Display(Name="Kategoria")]
        [Required (ErrorMessage = "Prosze podać cene")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
