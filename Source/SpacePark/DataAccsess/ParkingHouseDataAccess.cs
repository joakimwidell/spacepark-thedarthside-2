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
        private readonly Context _Context = new Context();
        private readonly PersonDataAccess _personDataAccess;
        private readonly VehicleDataAccess _vehicleDataAccess;
        private readonly int maxSpaces = 50;

        public ParkingHouseDataAccess(Context context, VehicleDataAccess vehicleDataAccess, PersonDataAccess personDataAccess)
        {
            _Context = context;
            _vehicleDataAccess = vehicleDataAccess;
            _personDataAccess = personDataAccess;
        }

        public async Task<string> ShowFreeSpaces()
        {
            var parkedPersons = await _personDataAccess.GetListOfPeopleAsync();
            var freeSpaces = maxSpaces - parkedPersons.Count();
            if (freeSpaces <= 0)
            {
                return "No available parkingplaces";
            }
            else
            {
                return $"{freeSpaces} available parkingplaces";
            }
        }
        
        public void TimeParked(Vehicle vehicle)
        {
            //new DateTime(2019, 9, 7, 15, 20, 35);
            DateTime start = (DateTime)vehicle.Arrival;
            DateTime end = DateTime.Now;
            TimeSpan testTimeSpan = end.Subtract(start);
            string hej = $"TimeSpan{testTimeSpan.Days}{testTimeSpan.Hours}{testTimeSpan.Minutes}{testTimeSpan.Minutes}";
        }

        public async Task<bool> IsPersonParked(string name)
        {
            var parkedPeople = await _personDataAccess.GetListOfPeopleAsync();
            return parkedPeople.Exists(x => x.Name == name);
        }

        public async Task PersonAndVehicleLeaving(Person person) 
        {
            var vehicle = person.Vehicle;
            await _vehicleDataAccess.DeleteStarshipAsync(vehicle);
            await _personDataAccess.DeletePersonAsync(person);
            // Ska det vara en SaveChanges här??
        }

        // TODO Generera en faktura $$$
    }
}



