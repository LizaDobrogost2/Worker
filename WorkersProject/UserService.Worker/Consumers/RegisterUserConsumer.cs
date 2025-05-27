using MassTransit;
using Shared.Contracts;

public class RegisterUserConsumer : IConsumer<RegisterUser>
{
    public Task Consume(ConsumeContext<RegisterUser> context)
    {
        var message = context.Message;
        Console.WriteLine($"User registered: {message.Username}, {message.Email}");
        return Task.CompletedTask;
    }
}
