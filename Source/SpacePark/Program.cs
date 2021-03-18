using System;
using static SpacePark.Person;
using System.Linq;
using System.Threading.Tasks;


namespace SpacePark
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!!");
            var context = new Context();
            var p = new PersonDataAccess(context);
            //await p.AddPersonAsync(new Person { FirstName = "Anton", LastName = "Johansson" });
           var listOfPeople = await  p.GetListOfPeople();
            foreach (var l in listOfPeople)
            {
                Console.WriteLine($"{l.FirstName} {l.LastName}");
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            //var parking = new ParkingHouse();
            //var x = parking.CheckAvailableParking();
            //Console.WriteLine(x);




            Console.ReadKey();


        }
    }
}
