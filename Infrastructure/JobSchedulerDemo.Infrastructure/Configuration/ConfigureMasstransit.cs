using GreenPipes;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace JobSchedulerDemo.Infrastructure.Configuration;
public static class ConfigureMassTransit
{
  public static void ConfigureMassTransitJobConsumer(this IServiceCollection services, 
    string? rabbitMqHost, string? azureServiceBus)
  {
    services.AddScoped<IJobPublisher, JobPublisher>();
    services.AddMassTransit(configure =>
    {
      configure.AddConsumers(typeof(JobConsumer));

      if (!string.IsNullOrEmpty(azureServiceBus))
      {
        configure.UsingAzureServiceBus((context, cfg) =>
        {
          cfg.Host(azureServiceBus);
          cfg.ConfigureEndpoints(context);
        });
      }

      if (!string.IsNullOrEmpty(rabbitMqHost))
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
      }

      services.AddMassTransitHostedService();
    });
  }

  public static void ConfigureMassTransitJobPublisher(this IServiceCollection services, 
    string? rabbitMqHost, string? azureServiceBus)
  {
    services.AddScoped<IJobPublisher, JobPublisher>();

    services.AddMassTransit(configure =>
    {
      if (!string.IsNullOrEmpty(azureServiceBus))
      {
        configure.UsingAzureServiceBus((context, cfg) =>
        {
          cfg.Host(azureServiceBus);
          cfg.ConfigureEndpoints(context);
        });
      }

      if (!string.IsNullOrEmpty(rabbitMqHost))
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
      }

      services.AddMassTransitHostedService();
    });
  }
}

