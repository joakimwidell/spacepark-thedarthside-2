using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace SpacePark
{
    public class SwApi : Menu, IDisposable
    {
        public string Name { get; set; }
        private string NamePath { get; set; }
        public string ShipName { get; set; }
        public string ShipPath { get; set; }
        HttpClient client = new HttpClient();

        public async Task<T> GetStarWarsObject<T>(string path) // för att kunna göra massa olika anrop
        {
            //Define your baseUrl
            string baseUrl = $"{path}"; //tog bort en slash
            T result = default;
            try
            {
                // using () // flera using kan läggas på varandra
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                using (HttpContent content = res.Content)
                {
                    //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                    var data = await content.ReadAsStringAsync();
                    if (content != null) //bytte från data till content
                    {
                        //Parse your data into a object.
                        result = JsonConvert.DeserializeObject<T>(data);

                    }
                    else
                    {
                        //If data is null log it into console.
                        Console.WriteLine("Data is null!");
                    }
                }
            }
            //Catch any exceptions and log it into the console.
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return result;
        }

        public async Task<SpaceTraveller> GetSpaceTraveller(string name)
        {
            NamePath = $"https://swapi.dev/api/people/?search={name}";
            var search = await GetStarWarsObject<SearchResultTraveller>(NamePath);

            //if (search.results.Any())
            //{
            if (search.results[0].name.ToLower() == name.ToLower())
            {
               
                // gör metod som skriver ut om person har starshipt och isf vilka
                // lista 
                // return name
                string selectedShip = await IsPersonStarShipOwner(search.results[0]);



            }
            else
            {
                Console.WriteLine("Du är har inte behörighet att parkera här");

            }

           
            return search.results[0];

            //}

            //return null;
        }

        public async Task<string> IsPersonStarShipOwner(SpaceTraveller person) // Byt namn på metod, nu är det en bool-metod
        {
            var menu = new Menu();
            List<string> starShips = new List<string>();

            foreach (var accessibleShip in person.starships)
            {
                var ship = await GetStarWarsObject<Starship>(accessibleShip);

                if (ship.name.ToLower() != null)
                {
                    starShips.Add(ship.name);
                }
                else
                {
                    Console.WriteLine("Du är har inte något fordon");
                }
            }

            // TODO Skicka in detta resultatet in i en metod som skapar upp person/Starship i datatbasen
            int starShipIndex = menu.ShowMenu("Choose Starship to park: ", starShips);
            Console.WriteLine("");
            Console.WriteLine($"You selected {starShips[starShipIndex]}");

            // Här nånstans stoppa in funktion för att skapa vehicle och person
            var starShip = new Models.Vehicle(starShips[starShipIndex]);
            var spaceMan = new Models.Person(person.name, starShip); 
            // enklast att skapa person efter Vehicle, så kommer rätt sak på rätt plats. Men vart göra av?? kanske lägga till en occupant på vehicle, 
            // då kan vi skapa person utifrån vehicle senare
            // Här skapar jag SpaceTraveller

            return starShips[starShipIndex];
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
