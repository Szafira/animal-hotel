using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Models
{
    public class zwierzak
    {
        [Key]
        public decimal id_zwierz { get; set; }
        public decimal id_klienta { get; set; }
        public string imie { get; set; }
        public string gatunek { get; set; }
        public string rasa { get; set; }
        public string wielkosc { get; set; }
        public string wiek { get; set; }
        public string dodatkowe_informacje { get; set; }

    }
}
