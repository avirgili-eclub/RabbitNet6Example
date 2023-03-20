using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.DAL.Data;
using Ordering.Domain.OrderModel;

namespace Ordering.DAL.Core.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context/*, ILogger logger*/) : base(context/*, logger*/)
    {
    }
    public override async Task<IEnumerable<Order>> All()
    {
        try
        {
            // _logger.LogInformation("Entra en All()");
            return await dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            // _logger.LogError(ex, "{Repo} All function error", typeof(OrderRepository));
            return new List<Order>();
        }
    }
    public override async Task<bool> Upsert(Order entity,  CancellationToken cancellationToken)
    {
        try
        {
            var existingOrder = await dbSet.Where(x => x.OrderId == entity.OrderId)
                .FirstOrDefaultAsync();

            if (existingOrder == null)
                return await Create(entity, cancellationToken);

            existingOrder.Description = entity.Description;
            existingOrder.Code = entity.Code;

            return true;
        }
        catch (Exception ex)
        {
            // _logger.LogError(ex, "{Repo} Upsert function error", typeof(OrderRepository));
            return false;
        }
    }
}