using System;
using static SpacePark.Models;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");
            var context = new Context();
            var person = new Person {FirstName = "Katt", LastName = "Gris" };
            context.Add<Person>(person);
            Console.WriteLine("tryck!!");
            Console.ReadKey();
            context.SaveChanges();

        }
    }
}
