using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePark
{
    public class PersonDataAccess
    {
        private readonly Context _Context;

        public PersonDataAccess(Context context)
        {
            _Context = context;
        }

        public async Task<Person> GetPersonByid(int id)
        {
            return await _Context.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
            return await _Context.Person.Include(p => p.Vehicle).FirstOrDefaultAsync(x => x.Name == name.ToLower());
        }

        public async Task<Vehicle> CheckOutSpaceShipAsync(Person person)
        {

            return await _Context.Vehicle.FirstOrDefaultAsync(x => x.Id == person.Vehicle.Id);

        }

        public async Task<List<Person>> GetListOfPeopleAsync()
        {
            return await _Context.Person.ToListAsync();
        }

        public async Task AddPersonAsync(Person person)
        {
            await _Context.AddAsync<Person>(person);
            await _Context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(Person person)
        {
            _Context.Remove(person);
            await _Context.SaveChangesAsync();
        }

        public Person CreatePerson(SpaceTraveller spaceTraveller, string starShip)
        {
            return new Person(spaceTraveller.Name, new Vehicle(starShip));
        }
    }
}
