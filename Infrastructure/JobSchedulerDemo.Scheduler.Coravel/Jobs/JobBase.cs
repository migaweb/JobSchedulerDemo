using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using MediatR;

namespace JobSchedulerDemo.Application.Jobs
{
    public abstract class JobBase
  {
    private readonly IMediator _mediator;

    public JobBase(IMediator mediator)
    {
      _mediator = mediator;
    }

    public async Task Run(string jobId)
    {
      string id = jobId;
      await _mediator.Send(new RunScheduledJobCommand { JobId = id });
    }
  }
}
