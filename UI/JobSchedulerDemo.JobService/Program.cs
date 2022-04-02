
using JobSchedulerDemo.Infrastructure.Configuration;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((builder, services) =>
    {
      services.ConfigureHangfireServer(builder);

      services.ConfigureMassTransitJobConsumer(builder.Configuration["RabbitMQHost"]);

      services.ConfigurePushMessages(builder);
    })
    .Build();

await host.RunAsync();
