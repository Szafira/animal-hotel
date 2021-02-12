using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Wpisz swoje imię")]
        [Display(Name = "Imię")]
      
        public string Imię { get; set; }

        [Required(ErrorMessage = "Wpisz swoje nazwisko")]
        [Display(Name = "Nazwisko")]

        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wpisz swój adres e-mail")]
        [Display(Name="Adres e-mail")]
        [EmailAddress(ErrorMessage="Wpisz poprawny adres e-mail")]
        public string Email { get; set; }

        

        [Required(ErrorMessage = "Wymagane*")]
        [Display(Name = "Miasto zamieszkania")]
        
        public string Miasto { get; set; }

        [Required(ErrorMessage = "Wymagane*")]
        [Display(Name = "Ulica")]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Wybierz silne hasło")]
        [Compare("ConfirmPassword",ErrorMessage ="Hasła są inne")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Potwierdź hasło")]
        [Display(Name = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }




    }
}
