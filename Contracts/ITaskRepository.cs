using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
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
