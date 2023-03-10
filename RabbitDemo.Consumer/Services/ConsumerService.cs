using RabbitDemo.Common.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitDemo.Consumer.Services;

public class ConsumerService : IConsumerService, IDisposable
{
    private readonly IModel _model;
    private readonly IConnection _connection;
    
    //Obtener de las variables de entorno, como por ejemplo de appsettings.json para mejor configuracion segun ambiente
    //de trabajo
    const string QUEUE_NAME = "TestNet6.q";
    const string EXCHANGE = "amq.direct";
    const string ROUTING_KEY = "TestNet6";
    
    public ConsumerService(IRabbitMqService rabbitMqService)
    {
        _connection = rabbitMqService.CreateChannel();
        _model = _connection.CreateModel();
        _model.QueueDeclare(QUEUE_NAME, durable: true, exclusive: false, autoDelete: false);
        _model.ExchangeDeclare(EXCHANGE, ExchangeType.Direct, durable: true, autoDelete: false);
        _model.QueueBind(QUEUE_NAME, EXCHANGE, ROUTING_KEY);
    }

    public async Task ReadMessgaes()
    {
        var consumer = new AsyncEventingBasicConsumer(_model);
        consumer.Received += async (ch, ea) =>
        {
            var body = ea.Body.ToArray();
            var text = System.Text.Encoding.UTF8.GetString(body);
            Console.WriteLine(text);
            await Task.CompletedTask;
            _model.BasicAck(ea.DeliveryTag, false);
        };
        _model.BasicConsume(QUEUE_NAME, false, consumer);
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        if (_model.IsOpen)
            _model.Close();
        if (_connection.IsOpen)
            _connection.Close();
    }
}