using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePark
{
    public class Models
    {
        public class Person
        {
            public int PersonID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

        }
        public class Vehicle
        {
            public int VehicleID { get; set; }
            public int PersonID { get; set; }
            public string Sort { get; set; }
        }
    }
}
