using MassTransit;
using Microsoft.EntityFrameworkCore;
using UserService.Worker.Data;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<RegisterUserConsumer>();
            x.AddConsumer<GetAllUsersConsumer>();
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("register-user-queue", e =>
                {
                    e.ConfigureConsumer<RegisterUserConsumer>(ctx);
                });

                cfg.ReceiveEndpoint("get-all-users-queue", e =>
                {
                    e.ConfigureConsumer<GetAllUsersConsumer>(ctx);
                });
            });
        });

        services.AddDbContext<UsersDbContext>(options =>
            options.UseNpgsql(context.Configuration.GetConnectionString("Postgres")));

        services.AddScoped<IUserRepository, UserRepository>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
    db.Database.Migrate();
}

host.Run();