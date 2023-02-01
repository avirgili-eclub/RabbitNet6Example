using RabbitDemo.Common.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitDemo.Consumer.Services;

public class HelloWorldConsumerService : IHelloWorldConsumerService, IDisposable
{
    private readonly IModel _model;
    private readonly IConnection _connection;
    
    //Obtener de las variables de entorno, como por ejemplo de appsettings.json para mejor configuracion segun ambiente
    //de trabajo
    const string QUEUE_NAME = "HelloWorldNetExchange.q";
    const string EXCHANGE = "amq.direct";
    private const string ROUTING_KEY = "HelloWorldNetExchange";
    
    public HelloWorldConsumerService(IRabbitMqService rabbitMqService)
    {
        _connection = rabbitMqService.CreateChannel();
        _model = _connection.CreateModel();
        _model.QueueDeclare(QUEUE_NAME, durable: true, exclusive: false, autoDelete: false);
        _model.ExchangeDeclare(EXCHANGE, ExchangeType.Direct, durable: true, autoDelete: false);
        _model.QueueBind(QUEUE_NAME, EXCHANGE, ROUTING_KEY);
    }
    
    public async Task ConsumeHelloWorldMessage()
    {
        var consumer = new AsyncEventingBasicConsumer(_model);
        consumer.Received += async (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            //Una vez obtenido el mensaje convertir al tipo de objecto que corresponde
            var message = System.Text.Encoding.UTF8.GetString(body);
            Console.WriteLine(message);
            await Task.CompletedTask;
            _model.BasicAck(eventArgs.DeliveryTag, false);
        };
        //autoAck poner verdadero, para que maneje automaticamente el reconocimiento de mensajes.
        //Al objeto consumer le pasamos nuestro custom consumer que creamos al inicio
        _model.BasicConsume(QUEUE_NAME, true, consumer);
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