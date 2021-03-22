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
            
            

            Console.ReadKey();
            context.SaveChanges();

            Console.ReadLine();
        }
    }
}
