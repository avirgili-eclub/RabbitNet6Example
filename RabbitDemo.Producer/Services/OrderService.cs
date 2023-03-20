using Ordering.DAL.Core.IConfiguration;
using Ordering.Domain.OrderModel;
using RabbitDemo.Common.Messaging;
using RabbitDemo.Producer.Model.Dto;

namespace RabbitDemo.Producer.Services;

public class OrderService : IOrderService
{
    private readonly IMessageProducer _messageProducer;
    // private readonly IUnitOfWork _uof;

    public OrderService(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
        // _uof = uof;
    }

    public async void SendOrder(OrderMessage message)
    {
        //Se puede agregar mas logica de negocio antes de enviar el mensaje.
        //.
        //.
        //.
        //TODO: Se puede usar algun mapper para hacer automatico el casteo de dto a entity
        //no se puede pasar directo el tipo esperado.
        Order newOrder = new Order();
        newOrder.Description = "asd";
        newOrder.OrderId = 1;
        newOrder.ClientId = 1;
        // var result = await _uof.Orders.Create(newOrder, new CancellationToken());
        //se envia el mensaje.
        // if (result.Equals(true))
            //Las propiedades "exchange", "routingKey", "queue" se deben obtener de una variable global final o de un 
            //property que es lo mas recomendable.
            await _messageProducer.SendMessageAsync("interfisa.direct", "interfisa.sol_approved", null, message);
    }
}