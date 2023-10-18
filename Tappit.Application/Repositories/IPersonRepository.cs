using Tappit.Domain;

namespace Tappit.Application.Repositories
{
    public interface IPersonRepository
    {
        Task<bool> CreatePersonAsync(Person person);
        Task<bool> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(Person person);
        Task<Person> GetPersonByIdAsync(int personId);
        Task<List<Person>> GetAllPersonAsync();
    }
}
