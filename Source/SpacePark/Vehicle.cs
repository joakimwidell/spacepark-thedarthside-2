using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace SpacePark
{
    public partial class Models
    {
        public class Vehicle
        {
            [Key]
            public int Id { get; set; }
            public string StarShipModel { get; set; }
            public DateTime? Arrival = DateTime.Now;

            public Vehicle()
            {

            }
            public Vehicle(string name)
            {
                StarShipModel = name;
            }
        }
    }
}

