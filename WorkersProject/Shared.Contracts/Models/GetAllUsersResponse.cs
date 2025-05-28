namespace Shared.Contracts.Models;
public record GetAllUsersResponse(IEnumerable<UserDto> Users);