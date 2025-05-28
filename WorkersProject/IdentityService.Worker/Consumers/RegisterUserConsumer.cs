using MassTransit;
using Shared.Contracts;

public class RegisterUserConsumer : IConsumer<RegisterUser>
{
    public async Task Consume(ConsumeContext<RegisterUser> context)
    {
        var cmd = context.Message;
        Console.WriteLine($"[UserWorker] Registering user: {cmd.Email}");

        // TODO: записать в БД
        await Task.CompletedTask;
    }
}
