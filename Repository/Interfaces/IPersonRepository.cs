using Entities;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync(CancellationToken cancellation);
        Task<bool> DeleteAsync(Guid Id, CancellationToken cancellation);
        Task<Person> GetUniqueAsync(Guid Id, CancellationToken cancellation);
        Task<bool> CreatePersonAsync(Person person, CancellationToken cancellation);
        Task<bool> UpdateAsync(Person person, CancellationToken cancellation);
    }
}
