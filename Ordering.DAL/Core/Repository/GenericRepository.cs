using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.DAL.Data;

namespace Ordering.DAL.Core.Repository;

public class GenericRepository <T>: IGenericRepository<T> where T : class
{
    protected ApplicationDbContext context;
    internal DbSet<T> dbSet;
    // public readonly ILogger _logger;
    private int _executionCount;
    
    public GenericRepository(
        ApplicationDbContext context)
    {
        this.context = context;
        //TODO: si da error quitar el this. de this.context.set
        this.dbSet = this.context.Set<T>();
        // _logger = logger;
    }

    public virtual async Task<T> GetById(Guid id)
    {
        return await dbSet.FindAsync(id) ?? throw new InvalidOperationException();
    }

    //TODO: verificar este metodo. Probablemente deberia ser un void o ver como retornar correctamente un Task.
    public async Task<bool> Create(T entity, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            ++ _executionCount;
            // _logger.LogInformation(
            //     "{ServiceName} working, execution count: {Count}",
            //     nameof(T),
            //     _executionCount);
            // _logger.LogInformation($"Se procedera a crear la entidad {entity}");
            await dbSet.AddAsync(entity, cancellationToken);
            return true;
        }
        //TODO: remove this.
        return false;
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Upsert(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(T entity)
    { 
        dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await dbSet.Where(predicate).ToListAsync();
    }

    public IQueryable<T> FindAll() => dbSet.AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
        dbSet.Where(expression).AsNoTracking();

    public virtual Task<bool> Upsert(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public void Update(T entity) => dbSet.Update(entity);

}