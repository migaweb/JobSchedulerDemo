using Hangfire;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Infrastructure.Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobSchedulerDemo.Scheduler.Hangfire.Configuration
{
  public static class ConfigureHangfire
  {
    public static void ConfigureHangfireSchedulerServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<IScheduler, HangfireScheduler>();
      services.AddHangfire(x => x.UseSqlServerStorage(GetHangfireConnectionString(configuration)));
      services.AddHangfireServer();
    }

    private static string GetHangfireConnectionString(IConfiguration configuration)
    {
      string dbName = configuration["HangfireDatabaseName"];
      string connectionStringFormat = configuration.GetConnectionString("HangfireDB");

      return string.Format(connectionStringFormat, dbName);
    }
  }
}
