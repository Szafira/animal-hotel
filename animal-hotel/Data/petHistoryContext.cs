using animal_hotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Data
{
    public class petHistoryContext : DbContext
    {
        internal readonly object rezerwacje;

        public petHistoryContext(DbContextOptions<petHistoryContext> options)
           : base(options)
        {

        }
        public DbSet<animal_hotel.Models.zwierzak> zwierzak { get; set; }
            
       
    }
}
