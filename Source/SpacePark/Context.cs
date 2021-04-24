using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpacePark.Person;
using static SpacePark.Vehicle;


namespace SpacePark
{
    public class Context : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder();
            //builder.SetBasePath(@"Data Source=(local)\SQLExpress01;Initial Catalog=SpacePark;Integrated Security=SSPI;");

            builder.AddJsonFile("appsettings.json"); //ORIGINAL

            var config = builder.Build();
            var defaultConnectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(defaultConnectionString);

        }
    }
}