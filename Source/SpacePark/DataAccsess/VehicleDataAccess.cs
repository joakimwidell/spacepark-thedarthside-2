using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpacePark
{
    public class VehicleDataAccess 
    {
        private readonly Context _Context = new();

        public async Task AddStarShipAsync(Vehicle starShip)
        {
            await _Context.AddAsync<Vehicle>(starShip);
            await _Context.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetListOfStarShipsAsync()
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