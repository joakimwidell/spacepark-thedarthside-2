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

        readonly HttpClient Client = new();

        public async Task<T> GetStarWarsObject<T>(string path)
        {
            string baseUrl = $"{path}";
            T result = default;
            try
            {
                using (HttpResponseMessage res = await Client.GetAsync(baseUrl))
                using (HttpContent content = res.Content)
                {
                    var data = await content.ReadAsStringAsync();
                    if (content != null)
                    {
                        result = JsonConvert.DeserializeObject<T>(data);
                    }
                    else
                    {
                        // TODO! Skriv ett bättre svar. Retry?
                        Console.WriteLine("Data is null!");
                    }
                }
            }

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

            try
            {
                if (search.results[0].Name.ToLower() == name.ToLower())
                {
                    return search.results[0];
                }
                else
                {
                    // TODO Hantera här!!
                    Console.WriteLine("You have to enter your full name...");
                }
            }
            catch (Exception)
            {
                // TODO Hantera här!!
                Console.WriteLine("You don't have authority to park here! Get out of here!!");
            };

            return null;
        }

        public async Task<string> ChooseStarShip(SpaceTraveller person)
        {
            if (!person.StarShips.Any())
            {
                Console.WriteLine("You don't have a spaceship to park. Next, please!");
                return "";
            }

            var menu = new Menu();
            List<string> starShips = new();
            
            foreach (var starShip in person.StarShips)
            {
                var search = await GetStarWarsObject<Starship>(starShip);
                starShips.Add(search.Name);
            }

            int starShipIndex = menu.ShowMenu("Choose Starship to park: ", starShips);

            return starShips[starShipIndex];
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
