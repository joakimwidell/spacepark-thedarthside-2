using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace SpacePark
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string StarShipModel { get; set; }
        public DateTime Arrival { get; set; }
        public double ShipLength { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(string starShipModel, double shipLength)
        {
            StarShipModel = starShipModel;
            ShipLength = shipLength;
            this.Arrival = DateTime.Now;
        }
    }
}

