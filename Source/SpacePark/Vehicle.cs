using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePark
{
    public partial class Models
    {
        public class Vehicle
        {
            [Key]
            public int Id { get; set; }
            public string StarShipModel { get; set; }
            public DateTime Arrival { get; set; } // Denna ges när man ankommer
            public DateTime? Depature { get; set; }// Denna när man lämanar
                                                  // Depature (TimeSpan) Arrival * Pris = Kostnad när man lämnar
        }
    }
}
