using RabbitDemo.Common.Messaging;
using RabbitDemo.Producer.Model.Dto;

namespace RabbitDemo.Producer.Services;

public class OrderService : IOrderService
{
    private readonly IMessageProducer _messageProducer;

    public OrderService(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }

    public async void SendOrder(OrderMessage message)
    {
        //Se puede agregar mas logica de negocio antes de enviar el mensaje.
        //.
        //.
        //.
        //se envia el mensaje.
        
        //Las propiedades "exchange", "routingKey", "queue" se deben obtener de una variable global final o de un 
        //property que es lo mas recomendable.
        await _messageProducer.SendMessageAsync("interfisa.direct", "interfisa.sol_approved", null, message);
    }
}