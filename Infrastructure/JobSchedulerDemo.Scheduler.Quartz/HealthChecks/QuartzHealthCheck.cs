using Microsoft.Extensions.Diagnostics.HealthChecks;
using Quartz;

namespace JobSchedulerDemo.Scheduler.Quartz.HealthChecks
{
  public class QuartzHealthCheck : IHealthCheck
  {
    private readonly ISchedulerFactory _schedulerFactory;

    public QuartzHealthCheck(ISchedulerFactory schedulerFactory)
    {
      _schedulerFactory = schedulerFactory;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
      var isHealthy = true;
      var result = new Dictionary<string, string>();

      var schedulers = await _schedulerFactory.GetAllSchedulers();

      foreach (var scheduler in schedulers)
      {
        result.Add($"{scheduler.SchedulerInstanceId}", $"{scheduler.SchedulerName}: IsStarted={scheduler.IsStarted}, StandBy={scheduler.InStandbyMode}");
      }

      if (isHealthy)
      {
        return 
            HealthCheckResult.Healthy(System.Text.Json.JsonSerializer.Serialize(result));
      }

      return 
          new HealthCheckResult(
              context.Registration.FailureStatus, "An unhealthy result.");

    }
  }
}
