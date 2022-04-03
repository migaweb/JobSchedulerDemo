
using JobSchedulerDemo.Application.Extensions;
using JobSchedulerDemo.Infrastructure.Configuration;
using JobSchedulerDemo.Persistence.Configurations;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((builder, services) =>
    {
      services.ConfigureHangfireServer(builder);

      services.ConfigureMassTransitJobConsumer(builder.Configuration["RabbitMQHost"]);

      services.ConfigurePushMessages(builder);

      services.ConfigureApplicationServices();

      services.ConfigurePersistenceServices(builder.Configuration);
    })
    .Build();

await host.RunAsync();
