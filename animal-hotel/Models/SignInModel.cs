using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Hasło")]
        public string Password { get; set; }
        [Display(Name ="Zapamiętaj hasło")]
        public bool RememberMe { get; set; }

    }
}
