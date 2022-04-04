
using JobSchedulerDemo.Application.Extensions;
using JobSchedulerDemo.Infrastructure.Configuration;
using JobSchedulerDemo.Persistence.Configurations;
using JobSchedulerDemo.Scheduler.Coravel.Configuration;
using JobSchedulerDemo.Scheduler.Hangfire.Configuration;
using JobSchedulerDemo.Scheduler.Immediate.Configuration;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((builder, services) =>
    {
      services.ConfigureMassTransitJobConsumer(builder.Configuration["RabbitMQHost"]);

      services.ConfigurePushMessages(builder);

      services.ConfigureApplicationServices();

      services.ConfigureCoravelSchedulerServices();
      //services.ConfigureHangfireSchedulerServices(builder);
      //services.ConfigureImmediateSchedulerServices();

      services.ConfigurePersistenceServices(builder.Configuration);
    })
    .Build();

await host.RunAsync();
