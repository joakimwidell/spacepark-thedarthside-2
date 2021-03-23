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
            return await _personContext.Person.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Person> GetPersonByName(string name)
        {
            return await _personContext.Person.FirstOrDefaultAsync(x => x.Name == name);
        }
        //public async Task<int> GetPersonByName(Person person)
        //{
        //    var sandra = (from a in _personContext.Vehicle
        //                                join c in _personContext.Clients on a.UserID equals c.UserID
        //                                where c.ClientID == yourDescriptionObject.ClientID
        //                                select a.Balance)
        //      .SingleOrDefault();




        //    return await hej.Vehicle;
        //}

        // hitta en person vars vehicleID = vechicle.ID
        public async Task<Vehicle> CheckOutSpaceShip(Person person)
        {

            return await _personContext.Vehicle.FirstOrDefaultAsync(x => x.Id == person.Vehicle.Id);

        }

        //public async Task<Person> GetPersonByLastName(string lastName)
        //{
        //    return await _context.Person.Where(x => x.LastName == lastName).FirstOrDefaultAsync();
        //}
        public async Task<List<Person>> GetListOfPeople()
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
