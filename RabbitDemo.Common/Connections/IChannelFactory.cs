using RabbitMQ.Client;

namespace RabbitDemo.Common.Connections;

public interface IChannelFactory
{
    IModel Create();
}