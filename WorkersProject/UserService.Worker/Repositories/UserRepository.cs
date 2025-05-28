using Shared.Contracts.Models;
using UserService.Worker.Data;

public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _context;

    public UserRepository(UsersDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        return _context.Users.Select(u => new UserDto(
            u.Id.ToString(),
            u.Email,
            u.Name,
            u.Role,
            u.CreatedAt
        )).ToList();
    }
}
