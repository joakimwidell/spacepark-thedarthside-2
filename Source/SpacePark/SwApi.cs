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
        //public SwApi(string name, string url)
        //{
        //    Name = name;
        //}
    
    public async void GetStarWarsLegends(string name)
    {
        //Define your baseUrl
        string baseUrl = $"https://swapi.dev/api/people/?search={name}/";
        
        try
        {
            //We will now define your HttpClient with your first using statement which will use a IDisposable.
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))

                using (HttpContent content = res.Content)
                {
                    //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                    string data = await content.ReadAsStringAsync();
                    //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
                    if (data != null)
                    {
                        //Parse your data into a object.
                        var dataObj = JObject.Parse(data);
                        //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                        //Which will convert it to a string, since each property value is a instance of JToken.
                        
                        //Person person = new Person(name: $"{dataObj["name"]}");
                        //Log your pokeItem's name to the Console.
                        Console.WriteLine("Person: {0}", dataObj);
                    }
                    else
                    {
                        //If data is null log it into console.
                        Console.WriteLine("Data is null!");
                    }
                }
            }
                //Catch any exceptions and log it into the console.
            } catch(Exception exception) {
                Console.WriteLine(exception);
        }
    }
}
}
