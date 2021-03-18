using System.ComponentModel.DataAnnotations;

namespace SpacePark
{
    public partial class Models
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
        }


    }
}
