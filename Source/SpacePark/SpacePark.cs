using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePark
{
    public class SpacePark : ParkingHouseDataAccess
    {
        private readonly Context _Context;
        private readonly SwApi _swApi = new();
        private readonly VehicleDataAccess _vehicelDataAccess;
        private readonly PersonDataAccess _personDataAccess;
        private readonly ParkingHouseDataAccess _parkingHouseDataAccess;
        private int select;
        public SpacePark(Context context, VehicleDataAccess vehicleDataAccess, PersonDataAccess personDataAccess, ParkingHouseDataAccess parkingHouseDataAccess) : base(context, vehicleDataAccess, personDataAccess)
        {
            _Context = context;
            _vehicelDataAccess = vehicleDataAccess;
            _personDataAccess = personDataAccess;
            _parkingHouseDataAccess = parkingHouseDataAccess;
        }

        public async Task Start()
        {


            var menu = new Menu();

            while (true)
            {
                Console.Clear();
                var freespaces = await _parkingHouseDataAccess.ShowFreeSpaces();

                Console.WriteLine($"Welcome to SpacePark! \nWe have {freespaces} available parking spots\n");
                if (freespaces! > 0)
                    select = menu.ShowMenu("Would you like to :", new List<string> { "Check out Spaceship", "Exit" });


                select = menu.ShowMenu("Would you like to :", new List<string> { "Park Spaceship", "Check out Spaceship", "Exit" });

                Console.Clear();

                if (select == 2)
                {
                    Console.WriteLine("Goodbye....");
                    await Task.Delay(2000);
                    Environment.Exit(100);
                }
                Console.Write("Please enter your full name: ");
                string starTraveler = Console.ReadLine().ToLower();

                switch (select)
                {
                    case 0:
                        if (await _parkingHouseDataAccess.IsPersonParked(starTraveler))
                        {
                            Console.WriteLine("Dude, you are already here, are you stupid?!");
                            await Task.Delay(2000);
                            break;
                        }
                        await EnterParkingHouse(starTraveler);
                        break;
                    case 1:
                        if (!await _parkingHouseDataAccess.IsPersonParked(starTraveler))
                        {
                            Console.WriteLine("Dude, you are not parked here!");
                            await Task.Delay(2000);
                            break;
                        }
                        await LeaveParkingHouse(starTraveler);
                        await Task.Delay(1000);
                        Console.WriteLine("Invoice sent to space-mail...");
                        await Task.Delay(2000);
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            }
        }
        private async Task EnterParkingHouse(string name)
        {
            Console.Clear();
            var spaceMan = await _swApi.GetSpaceTraveller(name);
            if (spaceMan == null)
                await Start();

            var spacemansStarship = await _swApi.ChooseStarShip(spaceMan);
            if (spacemansStarship == null)
                await Start();

            var famousSpaceTraveller = _personDataAccess.CreatePerson(spaceMan, spacemansStarship);
            await _personDataAccess.AddPersonAsync(famousSpaceTraveller);
            Console.WriteLine("Your spaceship have been parked...");
            await Task.Delay(2000);

        }
        private async Task LeaveParkingHouse(string name)
        {
            Console.Clear();
            var personLeaving = await _personDataAccess.GetPersonByNameAsync(name);
            double timeParked = _parkingHouseDataAccess.TimeParked(personLeaving.Vehicle);
            double costOfParking = _parkingHouseDataAccess.CostOfParking(timeParked);
            await Task.Delay(1000);
            Console.WriteLine($"The cost for you stay is ¤{costOfParking} pay and get the fuck ot of here!");

            await _parkingHouseDataAccess.PersonAndVehicleLeaving(personLeaving);
        }
    }
}
