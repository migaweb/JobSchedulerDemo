
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using MediatR;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Immediate;
public abstract class JobBase
{
  private readonly IMediator _mediator;

  public JobBase(IMediator mediator)
  {
    _mediator = mediator;
  }

  public async Task Run(string íd)
  {
    await _mediator.Send(new RunScheduledJobCommand { JobId = íd });
  }
}


