using RabbitMQ.Client.Events;

namespace RabbitDemo.Common.Messaging;

public interface IMessageConsumer
{
    void Consumer<T>(Action<T> handler) where T : class;
    void ConsumerTopic<T>(string topic, Action<T> handler) where T : class;
    Task ConsumerAsync<T>(Action<T> handler) where T : class, IMessage;
    Task ConsumerTopicAsync<T>(string topic, Action<T> handler) where T : class, IMessage;
    
    IMessageConsumer ConsumerAsync<T>(string queue, string routingKey, string exchange, 
        Func<T, BasicDeliverEventArgs, Task> handler) where T : class, IMessage;
    IMessageConsumer ConsumerTopicAsync<T>(string topic, T message) where T : class, IMessage;
}