using Entities;

namespace Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync(CancellationToken cancellation);
        Task<bool> DeleteTasksAsync(Guid Id, CancellationToken cancellation);
        Task<Tasks> GetUniqueTasksAsync(Guid Id, CancellationToken cancellation);
        Task<bool> CreateTasksAsync(Tasks tasks, CancellationToken cancellation);
        Task<bool> UpdateTasksAsync(Tasks tasks, CancellationToken cancellation);
    }

}
