using Microsoft.Extensions.Logging;
using Ordering.DAL.Core;
using Ordering.DAL.Core.IConfiguration;
using Ordering.DAL.Core.Repository;

namespace Ordering.DAL.Data;

public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    // private readonly ApplicationDbContext _context;
    private bool _disposed;
    private readonly ILogger _logger;
    public IOrderRepository Orders { get; private set; }
    
    public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
    {
        // _context = context;
        _logger = loggerFactory.CreateLogger("logs");

        Orders = new OrderRepository(context/*, _logger*/);
    }
    
    public async Task CompleteAsync()
    {
        try
        {
            // await _context.SaveChangesAsync();
            _logger.LogInformation("Tarea terminada.");
        }
        catch (Exception e)
        {
            // _logger.LogError(e.Message);
            Console.WriteLine(e);
            // throw;
        }

    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}