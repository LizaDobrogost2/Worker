using MassTransit;
using Microsoft.EntityFrameworkCore;
using UserService.Worker.Data;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<RegisterUserConsumer>();
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
            });
        });
        services.AddDbContext<UsersDbContext>(options =>
            options.UseNpgsql(context.Configuration.GetConnectionString("Postgres")));
    })
    .Build()
    .Run();
