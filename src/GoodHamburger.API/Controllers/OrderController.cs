using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}
