using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpacePark
{
    public interface IVehicleDataAccess
    {
        Task AddStarShipAsync(Vehicle starShip);
        Task DeleteStarshipAsync(Vehicle starShip);
        Task<List<Vehicle>> GetListOfStarShipsAsync();
    }
}