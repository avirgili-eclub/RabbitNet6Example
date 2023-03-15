using Microsoft.Extensions.Options;
using RabbitDemo.Common.Model;
using RabbitMQ.Client;

namespace RabbitDemo.Common.Configuration;

public class RabbitMqConfigurationService : IRabbitMqConfigurationService
{
    private readonly RabbitMqConfiguration _configuration;

    public RabbitMqConfigurationService(IOptions<RabbitMqConfiguration> options)
    {
        _configuration = options.Value;
    }

    public IConnection CreateChannel()
    {
        ConnectionFactory connection = new ConnectionFactory()
        {
            // UserName = _configuration.Username,
            // Password = _configuration.Password,
            // HostName = _configuration.HostName
            UserName = "eclub",
            Password = "eclub123!",
            HostName = "10.150.10.81"
        };
        //TODO: verificar si se deberia usar o no.
        connection.DispatchConsumersAsync = true;
        return connection.CreateConnection();
    }
}