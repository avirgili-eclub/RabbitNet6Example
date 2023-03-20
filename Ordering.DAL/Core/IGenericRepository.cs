using System.Linq.Expressions;

namespace Ordering.DAL.Core;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T> GetById(Guid id);
    Task<bool> Create(T entity, CancellationToken stoppingToken);
    Task<bool> Delete(Guid id);
    Task<bool> Upsert(T entity, CancellationToken stoppingToken);
    void Update(T entity);
    Task<bool> Delete(T entity);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
}