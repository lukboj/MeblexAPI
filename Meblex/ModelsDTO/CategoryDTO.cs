using MeblexData.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meblex.ModelsDTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Display(Name="Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]

        public string Description { get; set; }
    }
}
