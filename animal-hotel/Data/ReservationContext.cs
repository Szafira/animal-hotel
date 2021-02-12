using animal_hotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options)
           : base(options)
        {

        }
        public DbSet<animal_hotel.Models.rezerwacje> rezerwacje { get; set; }


    }
}
