using Hangfire;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Infrastructure.Scheduler.Hangfire;
using Microsoft.Extensions.Logging;

namespace JobSchedulerDemo.Infrastructure.Hangfire
{
  public class HangfireScheduler : IScheduler
  {
    private readonly ILogger<HangfireScheduler> _logger;

    public HangfireScheduler(ILogger<HangfireScheduler> logger)
    {
      _logger = logger;
    }

    public async Task<bool> Cancel(int jobId)
    {
      await Task.CompletedTask;
      return BackgroundJob.Delete(jobId.ToString());
    }

    public async Task<string> Schedule(string type, int jobId, int timeInSeconds)
    {
      await Task.CompletedTask;
      return ScheduleJob(type, timeInSeconds);
    }

    private static bool CancelJob(string jobId)
    {
      return BackgroundJob.Delete(jobId);
    }

    private string? ScheduleJob(string name, int timeInSeconds)
    {
      string? jobId = null;

      switch (name)
      {
        case nameof(Preplanning):
          jobId = BackgroundJob.Schedule<Preplanning>(p => p.Run(null), TimeSpan.FromSeconds(timeInSeconds));
          break;

        case nameof(Contract):
          jobId = BackgroundJob.Schedule<Contract>(c => c.Run(null), TimeSpan.FromSeconds(timeInSeconds));
          break;

        case nameof(Invoice):
          jobId = BackgroundJob.Schedule<Invoice>(i => i.Run(null), TimeSpan.FromSeconds(timeInSeconds));
          break;
        default:
          _logger.LogWarning("{Name} is an invalid job.", name);
          break;
      }

      return jobId;
    }
  }
}