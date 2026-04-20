using GoodHamburger.Application.Queries;
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
    public IActionResult GetOrders()
    {
        var orders = _mediator.Send(new GetOrdersQuery());
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = _mediator.Send(new GetOrderByIdQuery(id));
        return Ok(order);
    }

}
