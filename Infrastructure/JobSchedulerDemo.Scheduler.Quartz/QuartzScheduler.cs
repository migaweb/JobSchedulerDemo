using Microsoft.Extensions.Logging;
using Quartz;
using IJobScheduler = JobSchedulerDemo.Application.Contracts.Infrastructure.IScheduler;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Quartz
{
  public class QuartzScheduler : IJobScheduler
  {
    private readonly ILogger<QuartzScheduler> _logger;
    private readonly ISchedulerFactory _schedulerFactory;

    public QuartzScheduler(ILogger<QuartzScheduler> logger, ISchedulerFactory schedulerFactory)
    {
      _logger = logger;
      _schedulerFactory = schedulerFactory;
    }

    public async Task<bool> Cancel(string jobId)
    {
      return await CancelJob(jobId);
    }

    public async Task<string?> Schedule(string type, int jobId, int timeInSeconds)
    {
      await Task.CompletedTask;
      return await ScheduleJob(type, jobId.ToString(), timeInSeconds);
    }

    private async Task<bool> CancelJob(string jobId)
    {
      var jobKey = new JobKey(jobId, jobId);
      var scheduler = await _schedulerFactory.GetScheduler();

      if (await scheduler.CheckExists(jobKey))
      {
        // Method is not cluster aware,
        // so no cancellation occurs if the job is running on another instance. :(
        var interrupted = await scheduler.Interrupt(jobKey);
        
        if (!interrupted)
        {
          try
          {
            return await scheduler.DeleteJob(jobKey);
          }
          catch (Exception ex)
          {
            _logger.LogError(ex.Message);
          }
        }
        else
        {
          return true;
        }
      }

      return false;
    }

    private async Task<string?> ScheduleJob(string name, string jobId, int timeInSeconds)
    {
      IScheduler _scheduler = await _schedulerFactory.GetScheduler();
      switch (name)
      {
        case nameof(Preplanning):
          IJobDetail job = JobBuilder.Create<Preplanning>()
            .WithIdentity(jobId, jobId).UsingJobData("id", jobId).StoreDurably(true)
            .Build();

          // Trigger the job to run now, and then repeat every 10 seconds
          ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(jobId, jobId)
            .StartAt(DateTime.UtcNow.AddSeconds(100))
            .Build();
          await _scheduler.ScheduleJob(job, trigger);
          return jobId;

        case nameof(Contract):
          IJobDetail job1 = JobBuilder.Create<Contract>()
            .WithIdentity(jobId, jobId).UsingJobData("id", jobId).StoreDurably(true)
            .Build();

          // Trigger the job to run now, and then repeat every 10 seconds
          ITrigger trigger1 = TriggerBuilder.Create()
            .WithIdentity(jobId, jobId)
            .StartAt(DateTime.UtcNow.AddSeconds(timeInSeconds))
            .Build();
          await _scheduler.ScheduleJob(job1, trigger1);
          return jobId;

        case nameof(Invoice):
          IJobDetail job3 = JobBuilder.Create<Invoice>()
            .WithIdentity(jobId, jobId).UsingJobData("id", jobId).StoreDurably(true)
            .Build();

          // Trigger the job to run now, and then repeat every 10 seconds
          ITrigger trigger3 = TriggerBuilder.Create()
            .WithIdentity(jobId, jobId)
            .StartAt(DateTime.UtcNow.AddSeconds(timeInSeconds))
            .Build();
          await _scheduler.ScheduleJob(job3, trigger3);
          return jobId;
        default:
          _logger.LogWarning("{Name} is an invalid job.", name);
          return null;
      }
    }
  }
}