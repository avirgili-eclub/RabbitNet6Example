using Ordering.DAL.Core;
using Ordering.DAL.Core.IConfiguration;
using Ordering.DAL.Data;
using Ordering.Domain.OrderModel;
using RabbitDemo.Consumer.Services.RabbitMq;

namespace RabbitDemo.Consumer.Services;

public class MyScopedServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MyScopedServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public IOrderRepository Create()
    {
        return _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IOrderRepository>();
    }
}