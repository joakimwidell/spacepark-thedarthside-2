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
        private readonly Context _context;

        public PersonDataAccess(Context context)
        {
            _context = context;
        }
        public async Task<Person> GetPersonByid(int id)
        {
            return await _context.Person.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Person> GetPersonByFirstName(string Name)
        {
            return await _context.Person.Where(x => x.Name == Name).FirstOrDefaultAsync();
        }
        //public async Task<Person> GetPersonByLastName(string lastName)
        //{
        //    return await _context.Person.Where(x => x.LastName == lastName).FirstOrDefaultAsync();
        //}
        public async Task<List<Person>> GetListOfPeople()
        {
            return await _context.Person.ToListAsync();
        }
        public async Task AddPersonAsync(Person person)
        {
            await _context.AddAsync<Person>(person);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePersonAsync(Person person)
        {
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
