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
        private readonly Context _parkingHouseContext = new();
        private readonly PersonDataAccess _personDataAccess = new();
        private readonly VehicleDataAccess _vehicleDataAccess = new();
        private readonly int maxSpaces = 50;

      
        public double TimeParked(Vehicle vehicle)
        {
            DateTime start = (DateTime)vehicle.Arrival;
            DateTime end = DateTime.Now;
            return (end - start).TotalMinutes * vehicle.ShipLength;
        }

        public double CostOfParking(double timeParked)
        {
            return Math.Round(timeParked, 0) * 250 ;
        }

        public async Task<int> ShowFreeSpaces()
        {
            int occupiedSpaces = 0;
            var spaceships = await _vehicleDataAccess.GetListOfStarShipsAsync();

            if (spaceships != null)
                foreach (var s in spaceships)
                {
                    if (s.ShipLength > 1000)
                        occupiedSpaces += 10;
                    else if (s.ShipLength > 30)
                        occupiedSpaces += 3;
                    else if (s.ShipLength < 30)
                        occupiedSpaces++;
                }
            return maxSpaces - occupiedSpaces;
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
    }
}



