using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace animal_hotel.Data
{
    public class AnimalHotelcontext :DbContext

    {
        public AnimalHotelcontext(DbContextOptions<AnimalHotelcontext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AnimalHotel;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
