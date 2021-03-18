using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpacePark.Models;

namespace SpacePark
{
    public class Context : DbContext
    {

        public DbSet<Person> Person { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingHouse> ParkingHouses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-BG55CFP4\SQLEXPRESS;Initial Catalog=SpacePark;Trusted_Connection=True");
        }
    }
}
