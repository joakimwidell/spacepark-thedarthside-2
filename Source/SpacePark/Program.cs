using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var context = new Context();
            var vehicleDataAccess = new VehicleDataAccess(context);
            var personDataAccess = new PersonDataAccess(context);
            var parkingHouseDataAccess = new ParkingHouseDataAccess(context, vehicleDataAccess, personDataAccess);
            var spacePark = new SpacePark(context, vehicleDataAccess, personDataAccess, parkingHouseDataAccess);


            await spacePark.Start();

            //// Tömmer databasen på personer
            //var listOfPeople = await personDataAccess.GetListOfPeopleAsync();
            //foreach (var item in listOfPeople)
            //{
            //    context.Remove(item);
            //    context.SaveChanges();
            //}

            ////Tömmer databasen på starships
            //var listOfShips = await vehicleDataAccess.GetListOfStarShipsAsync();
            //foreach (var item in listOfShips)
            //{
            //    context.Remove(item);
            //    context.SaveChanges();
            //}
        }
    }
}
