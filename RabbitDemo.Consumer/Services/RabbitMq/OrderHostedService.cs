using Ordering.Domain.OrderModel;
using RabbitDemo.Common.Messaging;
using RabbitDemo.Producer.Model.Dto;

namespace RabbitDemo.Consumer.Services.RabbitMq;

public class OrderHostedService : BackgroundService
{
    private readonly IMessageConsumer _messageConsumer;
    private readonly ILogger<OrderHostedService> _logger;
    private readonly MyScopedServiceFactory _myScopedServiceFactory;
    //Se puede inyectar channel factory para poder declarar nuevos exchanges.
    public OrderHostedService(IMessageConsumer messageConsumer, ILogger<OrderHostedService> logger,/*
        IServiceScopeFactory serviceScopeFactory, IServiceProvider serviceProvider,*/ MyScopedServiceFactory myScopedServiceFactory)
    {
        _messageConsumer = messageConsumer;
        _logger = logger;
        _myScopedServiceFactory = myScopedServiceFactory;
        // _serviceProvider = serviceProvider;
        // _serviceScopeFactory = serviceScopeFactory;
    }


    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // using (var scope = _serviceProvider.CreateAsyncScope())
        // {
            // var scoped = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            // var resultServicesTypeOf = scope.ServiceProvider.GetServices(typeof(IUnitOfWork));
            // Console.WriteLine(resultServicesTypeOf);
            // var resultServicesTypeT = scope.ServiceProvider.GetServices<IUnitOfWork>();
            // Console.WriteLine(resultServicesTypeT);

            //TODO: obtener los parametros de un archivo de configuracion.
            _messageConsumer.ConsumerAsync<OrderMessage>("interfisa.sol_approved.q", "interfisa.sol_approved",
                "interfisa.direct", async /*Task<bool>*/ (msg, ea)  =>
                {
                    _logger.LogInformation($"Mensaje recibido de la orden id: {msg.OrderId} | cliente {msg.ClientId}");
                    _logger.LogInformation($"Mensaje proveniente de routingkey {ea.RoutingKey}");
                    _logger.LogInformation($"body: {msg}");
                    //TODO: Se puede usar algun mapper para hacer automatico el casteo de dto a entity
                    //no se puede pasar directo el tipo esperado.
                    Order newOrder = new Order();
                    newOrder.Description = msg.Description;
                    newOrder.OrderId = msg.OrderId;
                    newOrder.ClientId = msg.ClientId;

                    var uof = _myScopedServiceFactory.Create();
                    await uof.Create(newOrder, new CancellationToken());
                    await Task.CompletedTask;
                });
        // }

        return Task.CompletedTask;
    }
}
