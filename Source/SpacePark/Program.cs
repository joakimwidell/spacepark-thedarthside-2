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
            //var findLuke = await test.GetSpaceTraveller("Luke skywalker");
            
            
            // Om vi ska använda oss av ett fluent API för att göra alla queries till databasen. Hur ska vi då lösa flera tabeller?
            // Tänker vi rätt nu med en kedja av metoder mot swapi? Borde vi köra en radda metoder i program.cs istället?
            // Startmetod som skriver ut en cw och tar en crl som blir name?



            Console.ReadKey();
            context.SaveChanges();

            Console.ReadLine();
        }
    }
}
