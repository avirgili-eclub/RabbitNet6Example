using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitDemo.Common.Connections;
using RabbitDemo.Common.Messaging;
using RabbitMQ.Client;

namespace RabbitDemo.Common.Extensions;

public static class StartupExtension
{
    // public static void AddCommonService(this IServiceCollection services, IConfiguration configuration)
    // {
    //     services.Configure<RabbitMqConfiguration>(a => configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(a));
    //     services.AddSingleton<IRabbitMqConfigurationService, RabbitMqConfigurationConfigurationService>();
    // }

    public static void AddMessaging(this IServiceCollection services/*, IConfiguration configuration*/)
    {
        #region crear conexion
        var factory = new ConnectionFactory()
        {
            UserName = "eclub",
            Password = "eclub123!",
            HostName = "10.150.10.81"
        };
        var connection = factory.CreateConnection();
        services.AddSingleton(connection);
        
        //TODO: how to implement this way?
        // services.Configure<RabbitMqConfiguration>(a => configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(a));
        // services.AddSingleton<IRabbitMqConfigurationService, RabbitMqConfigurationService>();
        #endregion
        
        services.AddSingleton<ChannelAccessor>();
        services.AddSingleton<IChannelFactory, ChannelFactory>();
        services.AddSingleton<IMessageProducer, MessageProducer>();
        services.AddSingleton<IMessageConsumer, MessageConsumer>();
    }
}