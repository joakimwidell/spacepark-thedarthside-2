using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SpacePark.Models;

namespace SpacePark
{
    public class VehicleDataAccess
    {
        private readonly Context _Context;

        // Depature (TimeSpan) Arrival * Pris = Kostnad när man lämnar
        public VehicleDataAccess(Context context)
        {
            _Context = context;
        }
        public async Task AddStarShipAsync(Vehicle starShip)
        {

            await _Context.AddAsync<Vehicle>(starShip);
            await _Context.SaveChangesAsync();

        }
        public async Task<List<Vehicle>> GetListOfStarShips()
        {
            return await _Context.Vehicle.ToListAsync();
        }
        public async Task DeleteStarshipAsync(Vehicle starShip)
        {
            _Context.Remove(starShip);
            await _Context.SaveChangesAsync();
        }
    }
}