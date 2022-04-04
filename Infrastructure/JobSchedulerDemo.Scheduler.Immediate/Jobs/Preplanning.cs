
using MediatR;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Immediate;
public class Preplanning : JobBase
{
  public Preplanning(IMediator mediator) : base(mediator)
  {

  }

  public new async Task Run(string jobId)
  {
    await base.Run(jobId);
  }
}
