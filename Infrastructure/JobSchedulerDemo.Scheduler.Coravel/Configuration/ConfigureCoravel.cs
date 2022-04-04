using Coravel;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace JobSchedulerDemo.Scheduler.Coravel.Configuration;
public static class ConfigureCoravel
{
  public static void ConfigureCoravelSchedulerServices(this IServiceCollection services)
  {
    services.AddScoped<IScheduler, CoravelScheduler>();
    services.AddQueue();
    services.AddScheduler();
  }
}
