using System.ComponentModel.DataAnnotations;

namespace Meblex.ModelsDTO
{
    public class OpinionDTO
    {
        public int opinionid { get; set; }
        [Display(Name="Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]

        public string LastName { get; set; }
        [Display(Name = "Treść")]

        public string description { get; set; }
    }
}
