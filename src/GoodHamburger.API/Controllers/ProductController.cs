using GoodHamburger.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var menu = await _mediator.Send(new GetMenuQuery());
        return Ok(menu);
    }

    [HttpGet("GetProductsByOrderId/{orderId}")]
    public async Task<IActionResult> GetProductsByOrderId(Guid orderId)
    {
        var products = await _mediator.Send(new GetProductsByOrderIdQuery(orderId));
        return Ok(products);
    }
}
