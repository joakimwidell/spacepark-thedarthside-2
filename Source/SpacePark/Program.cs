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
            var person = new Person {  FirstName = "Sandra", LastName = "hdjsa" };

            context.Add<Person>(person);
            context.SaveChanges();
           
        }
    }
}
