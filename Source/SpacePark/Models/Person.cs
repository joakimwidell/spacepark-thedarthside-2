using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpacePark
{
    public class Person : IPerson
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Vehicle Vehicle { get; set; }

        public Person()
        {

        }

        public Person(string name, Vehicle starShip)
        {
            Name = name.ToLower();
            Vehicle = starShip;
        }
    }

}
