using GoodHamburger.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController : Controller
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetMenu()
    {
        var menu = await _mediator.Send(new GetMenuQuery());
        return Ok(menu);
    }
}
