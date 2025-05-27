using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Логирование
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// MassTransit + RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Gateway API V1");
});

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
