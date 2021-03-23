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
        private readonly Context _parkingHouseContext;

        //public var context = new Context();

        //private VehicleDataAccess _spaceShip = new VehicleDataAccess();
        //private PersonDataAccess _person;

        public ParkingHouseDataAccess(Context context)
        {
            _parkingHouseContext = context;
        }

        public async Task<bool> IsPersonParked(string name)
        {
            var personDataAccess = new PersonDataAccess(_parkingHouseContext);
            var parkedPeople = await personDataAccess.GetListOfPeopleAsync();
            return parkedPeople.Exists(x => x.Name == name);
        }

        public async Task PersonAndVehicleLeaving(Person person)
        {
            var vehicleDataAccess = new VehicleDataAccess(_parkingHouseContext);
            var personDataAccess = new PersonDataAccess(_parkingHouseContext);
            var test = person.Vehicle;
            await vehicleDataAccess.DeleteStarshipAsync(test);
            await personDataAccess.DeletePersonAsync(person);
        }

        // TO DO
        // - Metod för att kontrollera antalet parkerade travellers






    }
}



