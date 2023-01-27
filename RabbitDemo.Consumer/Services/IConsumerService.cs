using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitDemo.Consumer.Services;

public interface IConsumerService
{
    Task ReadMessgaes();
}

