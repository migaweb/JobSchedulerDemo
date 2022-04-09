using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Infrastructure.Scheduler.Immediate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JobSchedulerDemo.Scheduler.Immediate
{
  public class ImmediateScheduler : IScheduler
  {
    private readonly IMediator _mediator;
    private readonly ILogger<ImmediateScheduler> _logger;

    public ImmediateScheduler(IMediator mediator, ILogger<ImmediateScheduler> logger)
    {
      _mediator = mediator;
      _logger = logger;
    }

    public async Task<bool> Cancel(int jobId)
    {
      await Task.CompletedTask;
      return true;
    }

    public async Task<string?> Schedule(string type, int jobId, int timeInSeconds)
    {
      return await ScheduleJob(jobId.ToString(), type, timeInSeconds);
    }

    private async Task<string?> ScheduleJob(string jobId, string name, int timeInSeconds)
    {
      await Task.CompletedTask;
      //await Task.Delay(timeInSeconds);

      switch (name)
      {
        case nameof(Preplanning):
          //var preplanning = new Preplanning(_mediator);
          //await preplanning.Run(jobId);
          break;

        case nameof(Contract):
          //var contract = new Contract(_mediator);
          //await contract.Run(jobId);
          break;

        case nameof(Invoice):
          //var invoice = new Invoice(_mediator);
          //await invoice.Run(jobId);
          break;
        default:
          _logger.LogWarning("{Name} is an invalid job.", name);
          return null;
      }

      return jobId;
    }
  }
}