using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark
{

    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string StarShipModel { get; set; }
        public DateTime Arrival { get; set; } // Denna ges när man ankommer
        public DateTime Depature { get; set; }// Denna när man lämanar
                                              // Depature (TimeSpan) Arrival * Pris = Kostnad när man lämnar
        public Vehicle GetVehicleByid(int id)
        {
            var context = new Context();
            return context.Vehicle.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task AddVehicle(Vehicle vehicle)
        {
            var context = new Context();
            await context.AddAsync<Vehicle>(vehicle);
            await context.SaveChangesAsync();
        }
    }



}
