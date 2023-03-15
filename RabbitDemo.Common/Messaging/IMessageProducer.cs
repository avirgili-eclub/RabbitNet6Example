namespace RabbitDemo.Common.Messaging;

public interface IMessageProducer
{
    void SendMessage<T>(string exchange, string routingKey, string? queue, T message) where T : class;
    void SendTopicMessage<T>(string exchange, string topic, T message) where T : class;
    Task SendMessageAsync<T>(T message) where T : class, IMessage;
    Task SendMessageAsync<T>(string exchange, string routingKey, string? queue, T message, string messageId = default) where T : class, IMessage;
    Task SendTopicMessageAsync<T>(string topic, T message, string messageId = default) where T : class, IMessage;
}