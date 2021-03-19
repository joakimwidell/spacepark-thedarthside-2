using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark
{

    /*
     * Det finns flera fordon som heter lika men varje fordon har unik ID
     * Ett fordon kan ha flera personer, 
     * Personen som anländer måste ha ett fordon
     */

    public class ParkingHouse 
    {
        [Key]
        public int Id { get; set; }
        public int AmoutOfSpots { get; set; }

        //count amount of sports in list 
        public async Task<int> CheckAvailableParking()
        {
            var context = new Context();
            return context.Vehicle.ToList().Count();
        }
    }




}
