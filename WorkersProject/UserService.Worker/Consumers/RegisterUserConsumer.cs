using MassTransit;
using Shared.Contracts;
using UserService.Worker.Data;
using UserService.Worker.Models;

public class RegisterUserConsumer : IConsumer<RegisterUser>
{
    private readonly UsersDbContext _db;

    public RegisterUserConsumer(UsersDbContext db)
    {
        _db = db;
    }

    public async Task Consume(ConsumeContext<RegisterUser> context)
    {
        var msg = context.Message;
        var user = new UserEntity { Name = msg.Name, Email = msg.Email };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }
}
