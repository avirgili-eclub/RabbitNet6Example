using System.Text;
using Newtonsoft.Json;
using RabbitDemo.Common.Connections;
using RabbitMQ.Client;

namespace RabbitDemo.Common.Messaging;

internal sealed class MessageProducer : IMessageProducer
{
    
    private readonly IModel _channel;

    public MessageProducer(IChannelFactory channelFactory)
    {
        _channel = channelFactory.Create();
    }

    public void SendMessage<T>(string exchange, string routingKey, string? queue, T message) where T : class
    {

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);
        //para creaer properties para todos los que usan el defaultMessageProducer
        // var properties = _channel.CreateBasicProperties();
        _channel.QueueDeclare(queue);
        _channel.ExchangeDeclare(exchange, ExchangeType.Direct, true);
        _channel.BasicPublish(exchange: exchange, routingKey: routingKey, body: body);
    }

    public void SendTopicMessage<T>(string exchange, string topic, T message) where T : class
    {
        throw new NotImplementedException();
    }

    public Task SendMessageAsync<T>(T message) where T : class, IMessage => Task.CompletedTask;

    public Task SendMessageAsync<T>(string exchange, string routingKey, string? queue, T message, string messageId) where T : class, IMessage
    {
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);
        //para creaer properties para todos los que usan el defaultMessageProducer
        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;
        // var properties = _channel.CreateBasicProperties();
        // if(queue is not null && queue != "")
        //     _channel.QueueDeclare(queue);
        _channel.ExchangeDeclare(exchange, ExchangeType.Direct, true);
        _channel.BasicPublish(exchange: exchange, routingKey: routingKey, body: body, basicProperties: properties);
        return Task.CompletedTask;
    } 

    public Task SendTopicMessageAsync<T>(string topic, T message, string messageId) where T : class, IMessage => Task.CompletedTask;
}