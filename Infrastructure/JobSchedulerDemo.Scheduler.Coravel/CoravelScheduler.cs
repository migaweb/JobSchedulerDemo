using Coravel.Queuing.Interfaces;
using CScheduler = Coravel.Scheduling.Schedule.Interfaces;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Jobs;
using Microsoft.Extensions.Logging;

namespace JobSchedulerDemo.Scheduler.Coravel;
public class CoravelScheduler : IScheduler
{
  private readonly IQueue _queue;
    private readonly CScheduler.IScheduler _scheduler;
    private readonly ILogger<CoravelScheduler> _logger;

  public CoravelScheduler(IQueue queue, CScheduler.IScheduler scheduler , ILogger<CoravelScheduler> logger)
  {
    _queue = queue;
        _scheduler = scheduler;
        _logger = logger;
  }

  public async Task<bool> Cancel(int jobId)
  {
    await Task.CompletedTask;

    return true;
  }

  public async Task<string> Schedule(string type, int jobId, int timeInSeconds)
  {
    await Task.CompletedTask;
    return ScheduleJob(jobId, type, timeInSeconds);
  }

  private string ScheduleJob(int id, string name, int timeInSeconds)
  {
    string? jobId = id.ToString();
    Guid? cId = null; 

    switch (name)
    {
      case nameof(Preplanning):
        cId = _queue.QueueInvocableWithPayload<Preplanning, string>(jobId);
        break;

      case nameof(Contract):
        cId = _queue.QueueInvocableWithPayload<Contract, string>(jobId);
        break;

      case nameof(Invoice):
        cId = _queue.QueueInvocableWithPayload<Invoice, string>(jobId);
        break;
      default:
        _logger.LogWarning("{Name} is an invalid job.", name);
        break;
    }

    return jobId;
  }
}