using GoodHamburger.Application.Commands;
using GoodHamburger.Application.Commands.CreateOrderCommand;
using GoodHamburger.Application.Queries;
using GoodHamburger.Shared.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _mediator.Send(new GetOrdersQuery());
        return Ok(orders);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(Guid orderId)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(orderId));
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        var orderId = await _mediator.Send(new CreateOrderCommand(request));
        return Ok(orderId);
    }

    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder(Guid orderId)
    {
        var result = await _mediator.Send(new DeleteOrderCommand(orderId));
        return Ok(result);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request)
    {
        var result = await _mediator.Send(new UpdateOrderCommand(request));
        return Ok(result);
    }
}
