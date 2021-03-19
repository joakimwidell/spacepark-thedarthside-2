using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpacePark.Person;

namespace SpacePark
{
    public class Context : DbContext
    {
       
       
        public DbSet<Person> Person { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
            var defaultConnectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(defaultConnectionString);

        }
    }
}