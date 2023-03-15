using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Cors;
using RabbitDemo.Producer.Model.Dto;
using RabbitDemo.Producer.Services;

namespace RabbitDemo.Producer.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IOrderService _orderService;

    public HomeController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [DisableCors]
    [HttpPost]
    public IActionResult CreateOrder(OrderMessage orderDto)
    {
        //1. Aqui se llama al servicio de la orden para crear

        // Order order = new()
        // {
        //     ProductName = orderDto.ProductName,
        //     Price = orderDto.Price,
        //     Quantity = orderDto.Quantity
        // };
        // _context.Order.Add(order);
        // await _context.SaveChangesAsync();
        
        //2. Una vez creado la orden se envia al queue.
        //_messageProducer.SendMessageOrderCreated(order)
        _orderService.SendOrder(orderDto);
        
        //3. se retorna de ser necesario la orden creada o el id de la orden creada.
        //return Ok(new { id = order.Id });
        return Ok();
    }
}