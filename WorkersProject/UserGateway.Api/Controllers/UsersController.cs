using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;

namespace UserGateway.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public UsersController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUser user)
    {
        await _publishEndpoint.Publish(user);

        Console.WriteLine($"📤 Published: {user.Name} ({user.Email})");

        return Accepted();
    }
}
