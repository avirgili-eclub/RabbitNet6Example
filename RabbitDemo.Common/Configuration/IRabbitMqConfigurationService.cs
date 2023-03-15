using RabbitMQ.Client;

namespace RabbitDemo.Common.Configuration;
public interface IRabbitMqConfigurationService
{
    IConnection CreateChannel();
}

