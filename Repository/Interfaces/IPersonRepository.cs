using Entities;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync(CancellationToken cancellation);
        Task<bool> DeletePersonAsync(Guid Id, CancellationToken cancellation);
        Task<Person> GetUniquePersonAsync(Guid Id, CancellationToken cancellation);
        Task<bool> CreatePersonAsync(Person person, CancellationToken cancellation);
        Task<bool> UpdatePersonAsync(Person person, CancellationToken cancellation);
    }
}
