using Microsoft.EntityFrameworkCore;
using Tappit.Application.Repositories;
using Tappit.Domain;
using Tappit.Infrastructure.Context;

namespace Tappit.Infrastructure.Repositories
{
    public class FavouriteSportRepository : IFavouriteSportRepository
    {
        private readonly ApplicationDbContext _context;

        public FavouriteSportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignFavaouriteSport(FavouriteSport favouriteSport)
        {
            await _context.FavouriteSports.AddAsync(favouriteSport);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task ClearPersonPreviousFavourites(int personId)
        {
            var favSports = await _context.FavouriteSports
                .Where(fs => fs.PersonId == personId)
                .ToListAsync();

            if (favSports.Count > 0)
            {
                _context.FavouriteSports.RemoveRange(favSports);
                await _context.SaveChangesAsync();
            }
        }
    }
}
