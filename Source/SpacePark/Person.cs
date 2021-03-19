using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SpacePark
{

    //först tools =>något emellan => person
    //först tools =>något emellan => Vehical
    //först tools =>något emellan => Parkinspot
    // Visar relation mellan person och vehicale(one to many). Varje person är kopplad till en spaceship ID när personen ska parkera
    //public Vehicle Vehicle { get; set; }

    //public Person(string firstName, string lastName)
    //{
    //    FirstName = firstName;
    //    LastName = lastName;


    //}




    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        //API håller hela namn så måste splitta på anropet
        public string LastName { get; set; }

    }
}

