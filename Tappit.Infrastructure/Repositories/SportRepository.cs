using Microsoft.EntityFrameworkCore;
using Tappit.Application.Repositories;
using Tappit.Domain;
using Tappit.Infrastructure.Context;

namespace Tappit.Infrastructure.Repositories
{
    public class SportRepository: ISportRepository
    {
        private readonly ApplicationDbContext _context;
        public SportRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }
        public async Task<bool> CreateSportAsync(Sport sport)
        {
            await _context.Sports.AddAsync(sport);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSportAsync(Sport sport)
        {
            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Sport>> GetAllSportAsync()
        {
            return await _context.Sports
                .Include(p => p.FavouriteSports).ToListAsync();
        }

        public async Task<Sport> GetSportByIdAsync(int sportId)
        {
            return await _context.Sports
                .Where(p => p.SportId == sportId)
                .Include(p => p.FavouriteSports)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateSportAsync(Sport sport)
        {
            _context.Sports.Update(sport);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
   