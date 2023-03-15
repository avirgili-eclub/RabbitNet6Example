namespace RabbitDemo.Producer.Model.Entity;

public class Order
{
    private long _id;
    private string _description;
    private Client _client;
    private DateOnly _oderDate;
    private DateTime _created;
    
    public Order(long id, string description, Client client, DateOnly oderDate, DateTime created)
    {
        _id = id;
        _description = description;
        _client = client;
        _oderDate = oderDate;
        _created = created;
    }
}        
