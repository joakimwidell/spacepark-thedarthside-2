using System.Threading.Tasks;
using static SpacePark.Models;

namespace SpacePark
{
    public class VehicleDataAccess
    {
        private readonly Context _starShipContext;

        // Depature (TimeSpan) Arrival * Pris = Kostnad när man lämnar
        public VehicleDataAccess(Context context)
        {
            _starShipContext = context;
        }
        public async Task AddStarShipAsync(Vehicle starShip)
        {

            await _starShipContext.AddAsync<Vehicle>(starShip);
            await _starShipContext.SaveChangesAsync();

        }
    }
}