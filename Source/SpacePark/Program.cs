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
            var personDataAccess = new PersonDataAccess(context);
            var starShip = new Vehicle("volvo");

            var vehicleDataAccess = new VehicleDataAccess(context);
            //await vehicleDataAccess.AddStarShipAsync(starShip);
            
            //await personDataAccess.AddPersonAsync(new Person("sandra", starShip));


            var isThisLuke = await personDataAccess.GetPersonByName("sandra");
            //var personsStarShipid = await personDataAccess.GetPersonByName(isThisLuke);
            //var findeSpaceShip = await personDataAccess.CheckOutSpaceShip(isThisLuke);

            Console.ReadKey();

            Console.ReadLine();
        }
    }
}
