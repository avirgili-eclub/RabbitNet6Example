using RabbitDemo.Common.Messaging;

namespace RabbitDemo.Producer.Model.Dto;

public class OrderMessage : IMessage
{
    public long OrderId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ClientId { get; set; }
}