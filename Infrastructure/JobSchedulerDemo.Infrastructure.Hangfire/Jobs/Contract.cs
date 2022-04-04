
using Hangfire.Server;
using MediatR;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Hangfire;
public class Contract : JobBase
{
  public Contract(IMediator mediator) : base(mediator)
  {
  }

  public new async Task Run(PerformContext? context)
  {
    await base.Run(context);
  }
}
