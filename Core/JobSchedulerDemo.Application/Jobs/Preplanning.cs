using Hangfire.Server;
using JobSchedulerDemo.Application.Contracts;
using JobSchedulerDemo.Application.Contracts.Infrastructure;

namespace JobSchedulerDemo.Application.Jobs;
public class Preplanning : JobBase, IJob
{
  public Preplanning(IPushMessageSender pushMessageSender) : base(pushMessageSender)
  {

  }

  public async Task Run(PerformContext? context)
  {
    await Run(nameof(Preplanning), context);
  }
}
