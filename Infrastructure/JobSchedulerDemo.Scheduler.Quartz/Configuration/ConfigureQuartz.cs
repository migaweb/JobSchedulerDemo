
using JobSchedulerDemo.Infrastructure.Scheduler.Quartz;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace JobSchedulerDemo.Scheduler.Quartz.Configuration
{
  public static class ConfigureQuartz
  {
    public static void ConfigureQuartzSchedulerServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<Application.Contracts.Infrastructure.IScheduler, QuartzScheduler>();

      // if you are using persistent job store, you might want to alter some options
      services.Configure<QuartzOptions>(options =>
      {
        options.Scheduling.IgnoreDuplicates = true; // default: false
        options.Scheduling.OverWriteExistingData = true; // default: true
      });

      services.AddQuartz(q =>
      {
        // handy when part of cluster or you want to otherwise identify multiple schedulers
        q.SchedulerId = Environment.GetEnvironmentVariable(JobSchedulerDemo.Application.Constants.EnvironmentVariables.InstanceName) ?? "Scheduler";

        // we take this from appsettings.json, just show it's possible
        q.SchedulerName = Environment.GetEnvironmentVariable(JobSchedulerDemo.Application.Constants.EnvironmentVariables.InstanceName) ?? "Scheduler";

        // as of 3.3.2 this also injects scoped services (like EF DbContext) without problems
        q.UseMicrosoftDependencyInjectionJobFactory();

        // or for scoped service support like EF Core DbContext
        // q.UseMicrosoftDependencyInjectionScopedJobFactory();

        // these are the defaults
        q.UseSimpleTypeLoader();
        q.UseInMemoryStore();

        q.UseDefaultThreadPool(tp =>
        {
          tp.MaxConcurrency = 10;
        });

        // example of persistent job store using JSON serializer as an example

        q.UsePersistentStore(s =>
        {
          s.UseProperties = true;
          s.RetryInterval = TimeSpan.FromSeconds(15);
          s.UseSqlServer(sqlServer =>
          {
            sqlServer.ConnectionString = configuration.GetConnectionString("JobsDbConnectionString");
            // this is the default
            sqlServer.TablePrefix = "QRTZ_";
          });
          s.UseJsonSerializer();
          s.UseClustering(c =>
          {
            c.CheckinMisfireThreshold = TimeSpan.FromSeconds(20);
            c.CheckinInterval = TimeSpan.FromSeconds(10);
          });
        });

      });

      // we can use options pattern to support hooking your own configuration
      // because we don't use service registration api, 
      // we need to manually ensure the job is present in DI
      services.AddTransient<Contract>();
      services.AddTransient<Invoice>();
      services.AddTransient<Preplanning>();

      // Quartz.Extensions.Hosting allows you to fire background service that handles scheduler lifecycle
      services.AddQuartzHostedService(options =>
      {
        // when shutting down we want jobs to complete gracefully
        options.WaitForJobsToComplete = true;
      });
    }
  }
}
