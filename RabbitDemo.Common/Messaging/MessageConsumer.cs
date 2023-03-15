using RabbitMQ.Client.Events;

namespace RabbitDemo.Common.Messaging;

internal sealed class MessageConsumer : IMessageConsumer
{
    public void Consumer<T>(Action<T> handler) where T : class
    {
        throw new NotImplementedException();
    }

    public void ConsumerTopic<T>(string topic, Action<T> handler) where T : class
    {
        throw new NotImplementedException();
    }

    public async Task ConsumerAsync<T>(Action<T> handler) where T : class, IMessage => await Task.CompletedTask;

    public async Task ConsumerTopicAsync<T>(string topic, Action<T> handler) where T : class, IMessage =>
        await Task.CompletedTask;

    public IMessageConsumer ConsumerAsync<T>(string queue, string routingKey, string exchange, Func<T, BasicDeliverEventArgs, Task> handler) where T : class, IMessage
    {
        throw new NotImplementedException();
    }

    public IMessageConsumer ConsumerTopicAsync<T>(string topic, T message) where T : class, IMessage
    {
        throw new NotImplementedException();
    }
}