using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpacePark
{
    public partial class Models
    {
        public class Person
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            

            // Visar relation mellan person och vehicale(one to many). Varje person är kopplad till en spaceship ID när personen ska parkera
            public Vehicle Vehicle { get; set; }
           
            public Person(string name)
            {
                Name = name;
            }
        }

        public Person NewPerson (string name)
        {
            //var context = new Context();
            var person = new Person(name);
            //context.Add<Person>(person);
            //Console.WriteLine("tryck!!");
            //Console.ReadKey();
            //context.SaveChanges();

            return person;
        }
       

    }
}
