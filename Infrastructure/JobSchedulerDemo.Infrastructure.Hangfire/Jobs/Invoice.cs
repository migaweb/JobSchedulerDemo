
using Hangfire.Server;
using MediatR;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Hangfire;
public class Invoice : JobBase
{
  public Invoice(IMediator mediator) : base(mediator)
  {

  }

  public new async Task Run(PerformContext? context, CancellationToken cancellationToken)
  {
    await base.Run(context, cancellationToken);
  }
}

