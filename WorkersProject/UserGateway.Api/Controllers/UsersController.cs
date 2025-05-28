using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Models;

namespace UserGateway.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IRequestClient<GetAllUsersQuery> _client;

    public UsersController(IRequestClient<GetAllUsersQuery> client)
    {
        _client = client;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var response = await _client.GetResponse<GetAllUsersResponse>(new GetAllUsersQuery());
        return Ok(response.Message.Users);
    }
}