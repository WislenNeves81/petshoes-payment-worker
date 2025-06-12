using MassTransit;
using PetShoes.Payment.Worker;
using PetShoes.Payment.Worker.Core.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PurchaseOrderCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var configuration = context.GetRequiredService<IConfiguration>();
        cfg.Host(configuration.GetSection("RabbitMq:HostName").Value,
            h =>
            {
                h.Username(configuration.GetSection("RabbitMq:UserName").Value);
                h.Password(configuration.GetSection("RabbitMq:Password").Value);
            });

        cfg.ReceiveEndpoint(configuration.GetSection("RabbitMq:QueueName").Value, e =>
        {
            e.ConfigureConsumer<PurchaseOrderCreatedConsumer>(context);
        });
    });
});

builder.Services.AddHostedService<Worker>();
var host = builder.Build();
host.Run();