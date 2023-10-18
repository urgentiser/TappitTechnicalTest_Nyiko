using Tappit.Domain;

namespace Tappit.Application.Repositories
{
    public interface ISportRepository
    {
        Task<bool> CreateSportAsync(Sport sport);
        Task<bool> UpdateSportAsync(Sport sport);
        Task<bool> DeleteSportAsync(Sport sport);
        Task<Sport> GetSportByIdAsync(int Id);
        Task<List<Sport>> GetAllSportAsync();
    }
}
