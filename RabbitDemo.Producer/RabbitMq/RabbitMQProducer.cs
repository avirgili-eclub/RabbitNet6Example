using System.Text;
using Newtonsoft.Json;
using RabbitDemo.Common.Services;
using RabbitDemo.Producer.Model;
using RabbitMQ.Client;

namespace RabbitDemo.Producer.RabbitMq;

public class RabbitMQProducer : IMessageProducer //Nombre de producto y/o Servicio
{
    
    private readonly IRabbitMqService _rabbitMqService;
    // requires using Microsoft.Extensions.Configuration;
    //private readonly IConfiguration Configuration;

    public RabbitMQProducer(IRabbitMqService rabbitMqService)
    {
        _rabbitMqService = rabbitMqService;
    }

    //Metodo de ejemplo para mensajes genericos.
    public void SendMessage<T>(T message)
    {
        using var connection = _rabbitMqService.CreateChannel();
        using var model = connection.CreateModel();
            model.QueueDeclarePassive("TestNet6.q"); //el queue debe existir o lanzara un throw
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);
        model.BasicPublish(exchange: "amq.direct", routingKey: "TestNet6", body: body);
    }

    //Metodo ejemplo para envio de objetos especificos.
    public bool SendHelloWorld(HelloWorldDto helloWorldDto)
    {
        using var connection = _rabbitMqService.CreateChannel();
        using var model = connection.CreateModel();
        model.QueueDeclarePassive("HelloWorldNetExchange.q"); //el queue debe existir o lanzara un throw
        string json = JsonConvert.SerializeObject(helloWorldDto);
        byte[] body = Encoding.UTF8.GetBytes(json);

        var exchange = "amq.direct"; //Configuration["HelloWorldConfiguration:exchange"] ?? throw new InvalidOperationException();
        var routingKey = "HelloWorldNetExchange"; //Configuration["HelloWorldConfiguration:routing-key"] ?? throw new InvalidOperationException();

        model.BasicPublish(exchange,
            routingKey,
            false,
            basicProperties: null,
            body: body);

        return true;
    }
}