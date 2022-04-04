

using MediatR;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Immediate;
public class Contract : JobBase
{
  public Contract(IMediator mediator) : base(mediator)
  {
  }

  public new async Task Run(string jobId)
  {
    await base.Run(jobId);
  }
}
