namespace RabbitDemo.Producer.Model.Entity;

public class Client
{
    private long _id;
    private string _name;
    private string _documentNumber;

    public Client(long id, string name, string documentNumber)
    {
        _id = id;
        _name = name;
        _documentNumber = documentNumber;
    }
}