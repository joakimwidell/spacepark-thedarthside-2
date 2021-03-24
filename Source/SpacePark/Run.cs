using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePark
{
    public class Run
    {
        public async Task Start()
        {
            var swapi = new SwApi();
            var context = new Context();
            var vehicleDataAccess = new VehicleDataAccess(context);
            var personDataAccess = new PersonDataAccess(context);
            var parkingHouseDataAccess = new ParkingHouseDataAccess(context, vehicleDataAccess, personDataAccess);

            var freespaces = await parkingHouseDataAccess.ShowFreeSpaces();
            Console.WriteLine($"Welcome to SpacePark! \n{freespaces}");

            while (true)
            {
                Console.Write("Enter name :");
                string test = Console.ReadLine();
                var spaceMan = await swapi.GetSpaceTraveller(test);
                if (spaceMan != null)
                {
                    var spacemansStarship = await swapi.ChooseStarShip(spaceMan);

                }

                //var parkingGuest = personDataAccess.CreatePerson(spaceMan, spacemansStarship);
                //await personDataAccess.AddPersonAsync(parkingGuest);


            }

        }
        private async Task LeavParkingHouse() 
        {
        }
        private async Task EnterParkingHouse()
        {
        }




    }
}
