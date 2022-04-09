using Hangfire.Server;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using MediatR;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Hangfire;
public abstract class JobBase
{
  private readonly IMediator _mediator;

  public JobBase(IMediator mediator)
  {
    _mediator = mediator;
  }

  public async Task Run(PerformContext? context, CancellationToken cancellationToken)
  {
    if (context == null) return;
    string id = context.BackgroundJob?.Id ?? $"{DateTime.Now.Ticks}";
    await _mediator.Send(new RunScheduledJobCommand { JobId = id }, cancellationToken);
  }
}


