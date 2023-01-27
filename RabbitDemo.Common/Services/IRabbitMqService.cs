using RabbitMQ.Client;

namespace RabbitDemo.Common.Services;
public interface IRabbitMqService
{
    IConnection CreateChannel();
}

