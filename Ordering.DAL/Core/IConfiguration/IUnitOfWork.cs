namespace Ordering.DAL.Core.IConfiguration;

public interface IUnitOfWork
{
    IOrderRepository Orders { get; }

    Task CompleteAsync();
}