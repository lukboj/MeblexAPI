using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models
{
    public class Category
    {
        [Key]
        [Display(Name="ID Kategorii")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Wprowadź nazwe kategorii")]
        [Display(Name ="Nazwa Kategorii")]
        [StringLength(60, MinimumLength = 3)]

        public string Name { get; set; }
        [Required(ErrorMessage ="Wprowadź opis")]
        [Display(Name = "Opis Kategorii")]
        [StringLength(300, MinimumLength = 10)]

        public string Description { get; set; }
        public List<Product> Products { get; set; }

    }
}
