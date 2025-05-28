using MassTransit;
using Microsoft.Extensions.Hosting;

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
    })
    .Build()
    .Run();
