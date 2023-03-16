using System.Text;
using Newtonsoft.Json;
using RabbitDemo.Common.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitDemo.Common.Messaging;

internal sealed class MessageConsumer : IMessageConsumer
{
    private readonly IModel _channel;

    public MessageConsumer(IChannelFactory channelFactory) => _channel = channelFactory.Create();
    
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

    public IMessageConsumer ConsumerAsync<T>(string queue, string routingKey, string exchange, 
        Func<T, BasicDeliverEventArgs, Task> handler) where T : class, IMessage
    {
        //TODO: verificar si durable debe ser true.
        _channel.QueueDeclare(queue, true, false, autoDelete: false);
        
        //En el caso que se necesite crear el exchange desde el codigo debe ir aca con los parametros necesarios.
        // _channel.ExchangeDeclare(exchange, ExchangeType.Direct, durable: true, autoDelete: false, null);
        
        //Aqui se debe pasar los argumentos si es que se usaran posteriormente. arguments: 
        _channel.QueueBind(queue, exchange, routingKey);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));
            if (message != null) await handler(message, ea);
            _channel.BasicAck(ea.DeliveryTag, false);
        };
        _channel.BasicConsume(queue, autoAck: false, consumer);

        return this;
    }

    public IMessageConsumer ConsumerTopicAsync<T>(string topic, T message) where T : class, IMessage
    {
        throw new NotImplementedException();
    }
}