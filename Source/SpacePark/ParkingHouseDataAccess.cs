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
        private readonly PersonDataAccess personDataAccess = new(new Context());
        private readonly VehicleDataAccess vehicleDataAccess = new(new Context());

        public ParkingHouseDataAccess(Context context)
        {
            _Context = context;
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
            var parkedPeople = await personDataAccess.GetListOfPeopleAsync();
            return parkedPeople.Exists(x => x.Name == name);
        }

        public async Task PersonAndVehicleLeaving(Person person)
        {
            
            var test = person.Vehicle;
            await vehicleDataAccess.DeleteStarshipAsync(test);
            await personDataAccess.DeletePersonAsync(person);
        }

        // TO DO
        // - Metod för att kontrollera antalet parkerade travellers






    }
}



