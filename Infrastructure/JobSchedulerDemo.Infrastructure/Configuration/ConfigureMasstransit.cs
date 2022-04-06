using GreenPipes;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace JobSchedulerDemo.Infrastructure.Configuration;
public static class ConfigureMassTransit
{
  public static void ConfigureMassTransitJobConsumer(this IServiceCollection services, string rabbitMqHost)
  {
    services.AddScoped<IJobPublisher, JobPublisher>();
    services.AddMassTransit(configure =>
    {
      configure.AddConsumers(typeof(JobConsumer));

      configure.UsingRabbitMq((context, configurator) =>
      {
        configurator.Host(rabbitMqHost);
        configurator.ConfigureEndpoints(context);
        configurator.UseMessageRetry(retryConfigurator =>
        {
          retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
        });
      });

      services.AddMassTransitHostedService();
    });
  }

  public static void ConfigureMassTransitJobPublisher(this IServiceCollection services, string rabbitMqHost)
  {
    services.AddScoped<IJobPublisher, JobPublisher>();

    services.AddMassTransit(configure =>
    {
      configure.UsingRabbitMq((context, configurator) =>
      {
        configurator.Host(rabbitMqHost);
        configurator.ConfigureEndpoints(context);
        configurator.UseMessageRetry(retryConfigurator =>
        {
          retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
        });
      });


      services.AddMassTransitHostedService();
    });
  }
}

