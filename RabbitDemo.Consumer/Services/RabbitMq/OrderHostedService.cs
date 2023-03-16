using RabbitDemo.Common.Messaging;
using RabbitDemo.Producer.Model.Dto;

namespace RabbitDemo.Consumer.Services.RabbitMq;

public class OrderHostedService : BackgroundService
{
    private readonly IMessageConsumer _messageConsumer;
    private readonly ILogger<OrderHostedService> _logger;
    //Se puede inyectar channel factory para poder declarar nuevos exchanges.
    public OrderHostedService(IMessageConsumer messageConsumer, ILogger<OrderHostedService> logger)
    {
        _messageConsumer = messageConsumer;
        _logger = logger;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //TODO: obtener los parametros de un archivo de configuracion.
        _messageConsumer.ConsumerAsync<OrderMessage>("interfisa.sol_approved.q", "interfisa.sol_approved",
            "interfisa.direct", (msg, ea) =>
            {
                _logger.LogInformation($"Mensaje recibido de la orden id: {msg.OrderId} | cliente {msg.ClientId}");
                _logger.LogInformation($"Mensaje proveniente de routingkey {ea.RoutingKey}");
                _logger.LogInformation($"body: {msg}");
                return Task.CompletedTask;
            });
    }
}