using Tappit.Domain;

namespace Tappit.Application.Repositories
{
    public interface IFavouriteSportRepository
    {
        Task<bool> AssignFavaouriteSport(FavouriteSport favouriteSport);
        Task ClearPersonPreviousFavourites(int personId);
    }
}
