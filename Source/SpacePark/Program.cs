using System;
using static SpacePark.Models;
using System.Linq;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");
            //var models = new Models();
            var context = new Context();
            //context.Add<Person>(models.NewPerson("Sofie", "Bäverstrand"));
            var person = context.Person.Where(x => x.Id == 5).FirstOrDefault();
            context.Remove(person);

            var test = new SwApi();
            //await test.GetStarWarsObject("/people/?search=Luke Skywalker");
            var findLuke = await test.GetSpaceTraveller("katt");
            
            

            Console.ReadKey();
            context.SaveChanges();

            Console.ReadLine();
        }
    }
}
