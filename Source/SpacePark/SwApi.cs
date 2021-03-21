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
    public class SwApi : IDisposable
    {
        public string Name { get; set; }
        public string NamePath { get; set; }
        public string ShipName { get; set; }
        public string ShipPath { get; set; }
        HttpClient client = new HttpClient();

        public async Task<T> GetStarWarsObject<T>(string path) // för att kunna göra massa olika anrop
        {
            //Define your baseUrl
            string baseUrl = $"https://swapi.dev/api{path}"; //tog bort en slash
            T result = default;
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
               // using () // flera using kan läggas på varandra
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                using (HttpContent content = res.Content)
                {
                    //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                    var data = await content.ReadAsStringAsync();
                    //If the data is not null, parse the data to a C# object
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
            NamePath = $"/people/?search={name}";
            var search = await GetStarWarsObject<SearchResultTraveller>(NamePath);

            if (search.results.Any())
            {
                if (search.results.Length > 1)
                {
                    throw new Exception("Du är en snålåkare");
                }

                return search.results[0];
            }

            return null;
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
