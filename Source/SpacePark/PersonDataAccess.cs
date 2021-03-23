using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpacePark.Models;

namespace SpacePark
{
    public class PersonDataAccess
    {
        private readonly Context _personContext;

        public PersonDataAccess(Context context)
        {
            _personContext = context;
        }
        public async Task<Person> GetPersonByid(int id)
        {
            return await _personContext.Person.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Person> GetPersonByNameAsync(string name)
        {
            return await _personContext.Person.Include(p => p.Vehicle).FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Vehicle> CheckOutSpaceShipAsync(Person person)
        {

            return await _personContext.Vehicle.FirstOrDefaultAsync(x => x.Id == person.Vehicle.Id);

        }

        public async Task<List<Person>> GetListOfPeopleAsync()
        {
            return await _personContext.Person.ToListAsync();
        }
        public async Task AddPersonAsync(Person person)
        {
            await _personContext.AddAsync<Person>(person);
            await _personContext.SaveChangesAsync();
        }
        public async Task DeletePersonAsync(Person person)
        {
            _personContext.Remove(person);
            await _personContext.SaveChangesAsync();
        }
       
    }
}
