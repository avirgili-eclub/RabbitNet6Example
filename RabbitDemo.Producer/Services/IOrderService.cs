using RabbitDemo.Producer.Model.Dto;

namespace RabbitDemo.Producer.Services;

public interface IOrderService
{
    void SendOrder(OrderMessage orderMessage);
}