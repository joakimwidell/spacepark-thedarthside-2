using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePark
{
    public class ParkingHouseDataAccess
    {
        private readonly Context _parkingHouseContext = new Context();
        private readonly PersonDataAccess _personDataAccess;
        private readonly VehicleDataAccess _vehicleDataAccess;
        private readonly int maxSpaces = 4;

        public ParkingHouseDataAccess(Context context, VehicleDataAccess vehicleDataAccess, PersonDataAccess personDataAccess)
        {
            _parkingHouseContext = context;
            _vehicleDataAccess = vehicleDataAccess;
            _personDataAccess = personDataAccess;
        }
        public double TimeParked(Vehicle vehicle)
        {
            DateTime start = (DateTime)vehicle.Arrival;
            DateTime end = DateTime.Now;
            return (end - start).TotalMinutes;
        }

        public double CostOfParking(double timeParked)
        {
            return Math.Round(timeParked, 0) * 250;
        }

        public async Task<int> ShowFreeSpaces()
        {
            var parkedPersons = await _personDataAccess.GetListOfPeopleAsync();
            var freeSpaces = maxSpaces - parkedPersons.Count;
            return freeSpaces;
        }
        public async Task<bool> IsPersonParked(string name)
        {
            var parkedPeople = await _personDataAccess.GetListOfPeopleAsync();
            return parkedPeople.Exists(x => x.Name == name);
        }

        public async Task PersonAndVehicleLeaving(Person person)
        {
            await _vehicleDataAccess.DeleteStarshipAsync(person.Vehicle);
            await _personDataAccess.DeletePersonAsync(person);
            await _parkingHouseContext.SaveChangesAsync();
        }

        // TODO Generera en faktura $$$
    }
}



