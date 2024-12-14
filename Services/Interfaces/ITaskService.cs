using Shared.Dtos.Task;

namespace Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasks(CancellationToken cancellationToken);
        Task<TaskDto> GetTaskById(Guid taskId, CancellationToken cancellationToken);
        Task<bool> UpdateTask(Guid personId,Guid taskId, UpdateTaskDto task, CancellationToken cancellationToken);
        Task<bool> CreateTask(Guid personId, CreateTaskDto createTask, CancellationToken cancellationToken);
        Task<bool> DeleteTask(Guid taskId, CancellationToken cancellationToken);
        Task<bool> CheckTaskStatus(Guid taskId, CancellationToken cancellationToken);
        Task<bool> SetTaskStatus(Guid taskId,int setCode, CancellationToken cancellationToken);
        IEnumerable<TaskDto> GetAllOverdueTask(CancellationToken cancellation);
        Task<IEnumerable<TaskDto>> FetchPersonTask(Guid personId, CancellationToken cancellation);

    }
}
