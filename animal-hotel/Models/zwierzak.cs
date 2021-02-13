using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Models
{
    public class zwierzak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id_zwierz { get; set; }
        public decimal id_klienta { get; set; }
        public string imie { get; set; }
        public string gatunek { get; set; }
        public string rasa { get; set; }
        public string wielkosc { get; set; }
        public string wiek { get; set; }
        public string dodatkowe_informacje { get; set; }
        private void setId_zwierz()
        {
        }
    }
    public class rezerwacje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id_rezerwacji { get; set; }
        public decimal id_data { get; set; }
        public decimal id_zwierz { get; set; }

    }
    public class terminy
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id_data { get; set; }
        public DateTime termin { get; set; }
      
    }
}
