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

    public async Task<bool> Cancel(int jobId)
    {
      await Task.CompletedTask;
      return true; // BackgroundJob.Delete(jobId.ToString());
    }

    public async Task<string?> Schedule(string type, int jobId, int timeInSeconds)
    {
      await Task.CompletedTask;
      await ScheduleJob(type, jobId.ToString(), timeInSeconds);

      return jobId.ToString();
    }

    private async Task<bool> CancelJob(string jobId)
    {
      IScheduler _scheduler = await _schedulerFactory.GetScheduler();

      if (await _scheduler.CheckExists(new JobKey(jobId, jobId)))
      {
        await _scheduler.PauseJob(new JobKey(jobId, jobId));
        return await _scheduler.DeleteJob(new JobKey(jobId, jobId));
      }

      return true;
    }

    private async Task<string?> ScheduleJob(string name, string id, int timeInSeconds)
    {
      string? jobId = id;
      IScheduler _scheduler = await _schedulerFactory.GetScheduler();
      switch (name)
      {
        case nameof(Preplanning):
          IJobDetail job = JobBuilder.Create<Preplanning>()
            .WithIdentity(id, id).UsingJobData("id", jobId).StoreDurably(true)
            .Build();

          // Trigger the job to run now, and then repeat every 10 seconds
          ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(id, id)
            .StartAt(DateTime.UtcNow.AddSeconds(100))
            .Build();
          await _scheduler.ScheduleJob(job, trigger);
          break;

        case nameof(Contract):
          IJobDetail job1 = JobBuilder.Create<Contract>()
            .WithIdentity(id, id).UsingJobData("id", jobId).StoreDurably(true)
            .Build();

          // Trigger the job to run now, and then repeat every 10 seconds
          ITrigger trigger1 = TriggerBuilder.Create()
            .WithIdentity(id, id)
            .StartAt(DateTime.UtcNow.AddSeconds(timeInSeconds))
            .Build();
          await _scheduler.ScheduleJob(job1, trigger1);
          break;

        case nameof(Invoice):
          IJobDetail job3 = JobBuilder.Create<Invoice>()
            .WithIdentity(id, id).UsingJobData("id", jobId).StoreDurably(true)
            .Build();

          // Trigger the job to run now, and then repeat every 10 seconds
          ITrigger trigger3 = TriggerBuilder.Create()
            .WithIdentity(id, id)
            .StartAt(DateTime.UtcNow.AddSeconds(timeInSeconds))
            .Build();
          await _scheduler.ScheduleJob(job3, trigger3);
          break;
        default:
          _logger.LogWarning("{Name} is an invalid job.", name);
          break;
      }

      return jobId;
    }

    
  }
}