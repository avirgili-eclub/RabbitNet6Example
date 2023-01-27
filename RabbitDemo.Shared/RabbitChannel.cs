using RabbitMQ.Client;

namespace RabbitDemo.Shared;

public class RabbitChannel
{
    public static IModel Channel;
    private static IConnection _connection;
    public static IConnection Connection => _connection;

    public static void Init()
    {
        _connection = new ConnectionFactory
        {
            HostName = "xxxxxx",
            UserName = "xxx", 
            VirtualHost = "xxx",
            Password = "xxxxxx" 
        }.CreateConnection();

        Channel = _connection.CreateModel();
    }

    public static void CloseConnection()
    {
        if (Channel != null)
        {
            Channel.Close();
            Channel.Dispose();
        }

        if (_connection != null)
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}