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
        //public DateTime Depature { get; set; }
        public Vehicle()
        {

        }
        public Vehicle(string name)
        {
            StarShipModel = name;
            this.Arrival = DateTime.Now;
            //this.Depature = DateTime.Now;
        }


    }

}

