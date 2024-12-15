using Shared.Dtos.Task;

namespace Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAll(CancellationToken cancellationToken);
        Task<TaskDto?> GetById(Guid taskId, CancellationToken cancellationToken);
        Task<bool> Update(Guid personId,Guid taskId, UpdateTaskDto task, CancellationToken cancellationToken);
        Task<bool> Create(Guid personId, CreateTaskDto createTask, CancellationToken cancellationToken);
        Task<bool> Delete(Guid taskId, CancellationToken cancellationToken);
        Task<bool> CheckStatus(Guid taskId, CancellationToken cancellationToken);
        Task<bool> SetStatus(Guid taskId,int setCode, CancellationToken cancellationToken);
        IEnumerable<TaskDto> GetAllOverdueTask(CancellationToken cancellation);
        Task<IEnumerable<TaskDto>> FetchPersonTask(Guid personId, CancellationToken cancellation);

    }
}
