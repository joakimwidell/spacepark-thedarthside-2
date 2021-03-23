using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpacePark.Models;

namespace SpacePark
{
    public class ParkingHouseDataAccess  
    {
        private readonly Context _Context;
        private readonly PersonDataAccess _personDataAccess;
        private readonly VehicleDataAccess _vehicleDataAccess;

        public ParkingHouseDataAccess(Context context, VehicleDataAccess vehicleDataAccess, PersonDataAccess personDataAccess)
        {
            _Context = context;
            _vehicleDataAccess = vehicleDataAccess;
            _personDataAccess = personDataAccess;
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
            
            var test = person.Vehicle;
            await _vehicleDataAccess.DeleteStarshipAsync(test);
            await _personDataAccess.DeletePersonAsync(person);
        }

        // TO DO
        // - Metod för att kontrollera antalet parkerade travellers






    }
}



