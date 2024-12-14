using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        // Asynchronous methods for our CRUD
        Task<List<T>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges, CancellationToken cancellationToken = default);
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}
