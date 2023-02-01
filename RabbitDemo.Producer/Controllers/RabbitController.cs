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
    private readonly IMessageProducer _messageProducer;

    public RabbitController(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }

    [HttpPost]
    public IActionResult SendMessage()
    {
        
        _messageProducer.SendMessage("Hello");

        return Ok();
    }

    [DisableCors]
    [HttpPost]
    public IActionResult HelloWorldProducer(HelloWorldDto message)
    {
        //Example code with db context

        // Order order = new()
        // {
        //     ProductName = orderDto.ProductName,
        //     Price = orderDto.Price,
        //     Quantity = orderDto.Quantity
        // };
        // _context.Order.Add(order);
        // await _context.SaveChangesAsync();
        //
        //_messageProducer.SendMessageOrderCreated(order)
        //return Ok(new { id = order.Id });
        
        _messageProducer.SendHelloWorld(message);

        return Ok();
    }
}