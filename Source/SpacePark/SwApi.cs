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
    public class SwApi
    {
        public string Name { get; set; }
        public string NamePath { get; set; }
        public string ShipName { get; set; }
        public string ShipPath { get; set; }

        
        //public SwApi(string name, string url)
        //{
        //    Name = name;
        //}

        public async Task<T> GetStarWarsObject<T>(string path) // för att kunna göra massa olika anrop
        {
            //Define your baseUrl
            string baseUrl = $"https://swapi.dev/api{path}"; //tog bort en slash
            T result = default;
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient()) // flera using kan läggas på varandra
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                using (HttpContent content = res.Content)
                {
                    //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                    var data = await content.ReadAsStringAsync();
                    //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
                    if (content != null) //bytte från data till content
                    {
                        //Parse your data into a object.
                        //var dataobject = JObject.Parse(data);
                        //Console.WriteLine(data);
                        //var response = JObject.Parse(data);
                        //Console.WriteLine(response);
                        result = JsonConvert.DeserializeObject<T>(data);
                        //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                        //Which will convert it to a string, since each property value is a instance of JToken.
                        //var searchresult = CreateListFromSearch(response);

                        //Person person = new Person(name: $"{dataObj["name"]}");

                        //Log your pokeItem's name to the Console.
                        //Console.WriteLine($"Person: {Response}");
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
                return search.results[0];
            }

            return null;
        }

        //public List<SpaceTraveller> CreateListFromSearch(JObject response)
        //{
        //    List<SpaceTraveller> searchResult = new List<SpaceTraveller>();
        //    //for (int i = 0; i < response[count]; i++)
        //    //{
        //    //    var s = new SpaceTraveller
        //    //    (
        //    //        response(results[i] / name),
        //    //        response(results[i] / vehicles,
        //    //        response[results[i] / starships
        //    //    );
        //    //    searchResult.Add(s);
        //    //};

        //    return searchResult;
        //}
    }
}
