using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models
{
    public class Opinion
    { 
        [Key]
        public int opinionid { get; set; }
        [Display(Name="Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]

        public string LastName { get; set; }
        [Display(Name = "Treść")]

        public string description { get; set; }
        
        
    }


}
