using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitDemo.Common.Services;
using RabbitDemo.Producer.Model;
using RabbitDemo.Producer.RabbitMq;

namespace RabbitDemo.Producer.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RabbitController : ControllerBase
{
    // private readonly IRabbitMqService _rabbitMqService;
    private readonly IMessageProducer _messageProducer;

    public RabbitController(IMessageProducer messageProducer)
    {
        // _rabbitMqService = rabbitMqService;
        _messageProducer = messageProducer;
    }

    [HttpPost]
    public IActionResult SendMessage()
    {
        // using var connection = _rabbitMqService.CreateChannel();
        // using var model = connection.CreateModel();
        // var body = Encoding.UTF8.GetBytes("Hi");
        // model.BasicPublish("TestNetExchange",
        //     string.Empty,
        //     false,
        //     basicProperties: null,
        //     body: body);

        _messageProducer.SendMessage("Hello");

        return Ok();
    }

    [DisableCors]
    [HttpPost]
    public IActionResult HelloWorldProducer(HelloWorldDto message)
    {
        //Example code

        // Order order = new()
        // {
        //     ProductName = orderDto.ProductName,
        //     Price = orderDto.Price,
        //     Quantity = orderDto.Quantity
        // };
        // _context.Order.Add(order);
        // await _context.SaveChangesAsync();
        //
        //_messageProducer.SendHelloWorldObject(order)
        _messageProducer.SendHelloWorld(message);

        return Ok();
    }
}