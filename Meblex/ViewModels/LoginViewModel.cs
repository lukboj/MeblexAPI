using System.ComponentModel.DataAnnotations;

namespace Meblex.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="Nazwa Użytkownika")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]

        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
