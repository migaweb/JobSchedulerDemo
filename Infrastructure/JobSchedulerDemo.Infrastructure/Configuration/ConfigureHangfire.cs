using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobSchedulerDemo.Infrastructure.Configuration;
public static class ConfigureHangfire
{
  public static void ConfigureHangfireServer(this IServiceCollection services, HostBuilderContext builder)
  {
    services.AddHangfire(x => x.UseSqlServerStorage(GetHangfireConnectionString(builder)));
    services.AddHangfireServer();
  }

  private static string GetHangfireConnectionString(HostBuilderContext builder)
  {
    string dbName = builder.Configuration["HangfireDatabaseName"];
    string connectionStringFormat = builder.Configuration.GetConnectionString("HangfireDB");

    return string.Format(connectionStringFormat, dbName);
  }
}
