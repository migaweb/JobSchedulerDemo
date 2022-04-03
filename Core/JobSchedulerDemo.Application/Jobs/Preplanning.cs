using Hangfire.Server;
using JobSchedulerDemo.Application.Contracts;
using MediatR;

namespace JobSchedulerDemo.Application.Jobs;
public class Preplanning : JobBase, IJob
{
  public Preplanning(IMediator mediator) : base(mediator)
  {

  }

  public new async Task Run(PerformContext? context)
  {
    await base.Run(context);
  }
}
