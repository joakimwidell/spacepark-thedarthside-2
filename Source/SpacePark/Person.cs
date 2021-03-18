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


    public class Person:Models
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        //API håller hela namn så måste splitta på anropet
        public string LastName { get; set; }

    }
}

