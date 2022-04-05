using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using MediatR;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Quartz;
public abstract class JobBase
{
  private readonly IMediator _mediator;

  public JobBase(IMediator mediator)
  {
    _mediator = mediator;
  }

  public async Task Run(string jobId)
  {
    await _mediator.Send(new RunScheduledJobCommand { JobId = jobId });
  }
}


