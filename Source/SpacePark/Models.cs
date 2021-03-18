using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePark
{
    public class Models
    {
        public class Person
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            //API håller hela namn så måste splitta på anropet
            public string LastName { get; set; }

        }
        public class Vehicle
        {
            [Key]
            public int Id { get; set; }
            public int PersonId { get; set; }
            public string StarShipModel { get; set; }
            public DateTime Arrival { get; set; } // Denna ges när man ankommer
            public DateTime Depature { get; set; }// Denna när man lämanar
                                                  // Depature (TimeSpan) Arrival * Pris = Kostnad när man lämnar
        }

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
