using Microsoft.EntityFrameworkCore;
using Tappit.Application.Repositories;
using Tappit.Domain;
using Tappit.Infrastructure.Context;

namespace Tappit.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreatePersonAsync(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePersonAsync(Person person)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Person>> GetAllPersonAsync()
        { 
            return await _context.People
                .Include(c => c.FavouriteSports)
                .ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int personId)
        {
            return await _context.People
                .Where(c => c.PersonId == personId)
                .Include(c => c.FavouriteSports)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}