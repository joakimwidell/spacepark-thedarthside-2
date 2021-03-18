using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpacePark.Models;

namespace SpacePark
{
    public class Context : DbContext
    {
        string Sandra = "";
        string Joakim;
        string Randa;
        string Sofie;
       
        public DbSet<Person> Person { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<ParkingHouse> ParkingHouse { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Sandra);

           
        }
    }
}