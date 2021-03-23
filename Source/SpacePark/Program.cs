using System;
using static SpacePark.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //var models = new Models();
            var context = new Context();
            //context.Add<Person>(models.NewPerson("Sofie", "Bäverstrand"));
            //var person = context.Person.Where(x => x.Id == 5).FirstOrDefault();
            //context.Remove(person);

            var test = new SwApi();
            //await test.GetStarWarsObject("/people/?search=Luke Skywalker");
            //var findLuke = await test.GetSpaceTraveller("Darth vader");
           

            var vehicleDataAccess = new VehicleDataAccess(context);
            //await vehicleDataAccess.AddStarShipAsync(starShip);
      
               



            //// Skapar en volvo och en sandra
            var personDataAccess = new PersonDataAccess(context);
            var starShip = new Vehicle("x-wing");
            //await personDataAccess.AddPersonAsync(new Person("Luke Skywalker", starShip));
            //Person luke = await personDataAccess.GetPersonByNameAsync("luke skywalker");
            //var listOfpeople = await personDataAccess.GetListOfPeopleAsync();


            //// Tömmer databasen på starships
            //var listOfShips = await vehicleDataAccess.GetListOfStarShips();
            //foreach (var item in listOfShips)
            //{
            //    context.Remove(item);
            //    context.SaveChanges();
            //}


            //// Hämtar personinfo
            //var personDataAccess = new PersonDataAccess(context);
            //var isThisLuke = await personDataAccess.GetPersonByNameAsync("sandra");


            //var personsStarShipid = await personDataAccess.GetPersonByName(isThisLuke);
            //var findeSpaceShip = await personDataAccess.CheckOutSpaceShip(isThisLuke);





            // Tar bort en parkeringsgäst
            var parkingHouseDataAccess = new ParkingHouseDataAccess(context);
            var yesorno = await parkingHouseDataAccess.IsPersonParked("Luke Skywalker");

            //await parkingHouseDataAccess.PersonAndVehicleLeaving(isThisLuke);

            Console.ReadKey();

            Console.ReadLine();
        }
    }
}
