using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<List<T>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _repositoryContext.Set<T>().AsNoTracking().ToList(), cancellationToken);
        }
        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges, CancellationToken cancellationToken = default)
        {
            if (!trackChanges)
            {
                return await Task.Run(() => _repositoryContext.Set<T>().Where(expression).AsNoTracking(), cancellationToken);
            }
            else
            {
                return await Task.Run(() => _repositoryContext.Set<T>().Where(expression), cancellationToken);
            }
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _repositoryContext?.Set<T>().Add(entity), cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                _repositoryContext?.Set<T>().Update(entity);
                _repositoryContext.Entry(entity).State = EntityState.Modified;
            }, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _repositoryContext?.Set<T>().Remove(entity), cancellationToken);
        }

    }
}
