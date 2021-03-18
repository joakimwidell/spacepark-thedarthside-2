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
            public string FirstName { get; set; }
            //API håller hela namn så måste splitta på anropet
            public string LastName { get; set; }

            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        public Person NewPerson (string firstName, string lastName)
        {
            //var context = new Context();
            var person = new Person(firstName, lastName);
            //context.Add<Person>(person);
            //Console.WriteLine("tryck!!");
            //Console.ReadKey();
            //context.SaveChanges();

            return person;
        }
       

    }
}
