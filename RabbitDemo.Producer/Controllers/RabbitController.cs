using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitDemo.Common.Services;

namespace RabbitDemo.Producer.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RabbitController : ControllerBase
{
    private readonly IRabbitMqService _rabbitMqService;

    public RabbitController(IRabbitMqService rabbitMqService)
    {
        _rabbitMqService = rabbitMqService;
    }

    // [Route("sendmessage")]
    [HttpPost]
    public IActionResult SendMessage()
    {
        using var connection = _rabbitMqService.CreateChannel();
        using var model = connection.CreateModel();
        var body = Encoding.UTF8.GetBytes("Hi");
        model.BasicPublish("TestNetExchange",
            string.Empty,
            false,
            basicProperties: null,
            body: body);

        return Ok();
    }
    [HttpPost]
    public IActionResult HelloWorldProducer()
    {
        using var connection = _rabbitMqService.CreateChannel();
        using var model = connection.CreateModel();
        var body = Encoding.UTF8.GetBytes("Hi");
        model.BasicPublish("TestNetExchange",
            string.Empty,
            false,
            basicProperties: null,
            body: body);

        return Ok();
    }
}