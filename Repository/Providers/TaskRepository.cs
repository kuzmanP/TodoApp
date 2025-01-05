
using Entities;
using Repository.Interfaces;

namespace Repository.Providers
{
    public class TaskRepository : RepositoryBase<Tasks>, ITaskRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public TaskRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Tasks>> GetAllAsync(CancellationToken cancellation)
        {
            var tasks = await FindAllAsync(cancellation);
            return tasks;
        }

        public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellation)
        {
            var entity = await GetUniqueAsync(Id, cancellation);
            await DeleteAsync(entity, cancellation);
            return true;
        }

        public async Task<Tasks> GetUniqueAsync(Guid Id, CancellationToken cancellation)
        {
            var uniqueTask = await FindByConditionAsync(l => l.Id.Equals(Id), trackChanges: false, cancellation);
            var result = uniqueTask.SingleOrDefault();
            return result;
        }


        public async Task<bool> CreateTaskAsync(Tasks tasks, CancellationToken cancellation)
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

        public async Task<bool> UpdateTaskAsync(Tasks tasks, CancellationToken cancellation)
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
