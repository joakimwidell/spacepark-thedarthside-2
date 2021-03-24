using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePark
{
    public class Run
    {
        private readonly ParkingHouseDataAccess _parkingHouseDataAccess;
        private readonly PersonDataAccess _personDataAccess;
        private readonly VehicleDataAccess _vehicleDataAccess;

        public Run(ParkingHouseDataAccess parkingHouseDataAccess, VehicleDataAccess vehicleDataAccess, PersonDataAccess personDataAccess)
        {
            _parkingHouseDataAccess = parkingHouseDataAccess;
            _vehicleDataAccess = vehicleDataAccess;
            _personDataAccess = personDataAccess;
        }
        public async void Start()
        {
            var freespaces = await _parkingHouseDataAccess.ShowFreeSpaces();
            Console.WriteLine($"Welcome to SpacePark! {freespaces}");
        }
    }
}
