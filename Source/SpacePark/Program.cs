using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var spacePark = new SpacePark();

            await spacePark.Start();

           
        }
    }
}
