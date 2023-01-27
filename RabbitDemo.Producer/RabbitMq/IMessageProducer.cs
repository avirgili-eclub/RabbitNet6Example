using RabbitDemo.Producer.Model;

namespace RabbitDemo.Producer.RabbitMq;

public interface IMessageProducer
{
    void SendMessage<T> (T message);
    void SendHelloWorldObject(HelloWorldDto helloWorldDto);
}