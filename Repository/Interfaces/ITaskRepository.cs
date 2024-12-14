using Entities;

namespace Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Tasks>> GetAllAsync(CancellationToken cancellation);
        Task<bool> DeleteAsync(Guid Id, CancellationToken cancellation);
        Task<Tasks> GetUniqueAsync(Guid Id, CancellationToken cancellation);
        Task<bool> CreateAsync(Tasks tasks, CancellationToken cancellation);
        Task<bool> UpdateAsync(Tasks tasks, CancellationToken cancellation);
    }

}
