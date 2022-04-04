using Coravel.Pro;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobSchedulerDemo.Persistence.Configurations;

public static class PersistenceServiceRegistration
{
  public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<ScheduledJobsDbContext>(options =>
      options.UseSqlServer(
        configuration.GetConnectionString("JobsDbConnectionString")), ServiceLifetime.Transient);

    services.AddCoravelPro(typeof(ScheduledJobsDbContext));

    services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    services.AddTransient<IScheduledJobRepository, ScheduledJobRepository>();

    return services;
  }

  public static IApplicationBuilder CreateScheduledJobsDatabase(this IApplicationBuilder app, IServiceProvider serviceProvider)
  {
    using (var scope = serviceProvider.CreateScope())
    {
      var db = scope.ServiceProvider.GetRequiredService<ScheduledJobsDbContext>();
      db.Database.Migrate();

      return app;
    }
  }
}
