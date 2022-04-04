

using MediatR;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Immediate;
public class Invoice : JobBase
{
  public Invoice(IMediator mediator) : base(mediator)
  {

  }

  public new async Task Run(string jobId)
  {
    await base.Run(jobId);
  }
}

