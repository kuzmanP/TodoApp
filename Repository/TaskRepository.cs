using Contracts;
using Entities;

namespace Repository
{
    public class TaskRepository: RepositoryBase<Tasks>,ITaskRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public TaskRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        
        public async Task<IEnumerable<Tasks>> GetAllTasksAsync(CancellationToken cancellation)
        {
            var tasks = await FindAllAsync(cancellation);
            return tasks;
        }

        public async Task<bool> DeleteTasksAsync(Guid Id, CancellationToken cancellation)
        {
            var entity = await GetUniqueTasksAsync(Id, cancellation);
            await DeleteAsync(entity, cancellation);
            return true;
        }

        public async Task<Tasks> GetUniqueTasksAsync(Guid Id, CancellationToken cancellation)
        {
            var uniqueTask = await FindByConditionAsync(l => l.Id.Equals(Id), trackChanges: false, cancellation);
            var result = uniqueTask.SingleOrDefault();
            return result;
        }


        public async Task<bool> CreateTasksAsync(Tasks tasks, CancellationToken cancellation)
        {
            try
            {
                await CreateAsync(tasks, cancellation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTasksAsync(Tasks tasks, CancellationToken cancellation)
        {
            try
            {
                await UpdateAsync(tasks, cancellation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
