using RabbitDemo.Producer.Model;

namespace RabbitDemo.Producer.RabbitMq;

public class RabbitMQProducer : IMessageProducer
{
    public void SendMessage<T>(T message)
    {
        throw new NotImplementedException();
    }

    public void SendHelloWorldObject(HelloWorldDto helloWorldDto)
    {
        throw new NotImplementedException();
    }
}