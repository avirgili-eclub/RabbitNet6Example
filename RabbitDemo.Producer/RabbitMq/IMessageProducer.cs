using RabbitDemo.Producer.Model;

namespace RabbitDemo.Producer.RabbitMq;

public interface IMessageProducer //Aqui deberia ir nombre de producto y/o servicio
{
    //Metodo de ejemplo para mensajes genericos.
    void SendMessage<T> (T message);
    //Metodo ejemplo para envio de objetos especificos.
    bool SendHelloWorld(HelloWorldDto helloWorldDto);
}