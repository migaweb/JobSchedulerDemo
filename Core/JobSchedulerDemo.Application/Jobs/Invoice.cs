using Hangfire.Server;
using JobSchedulerDemo.Application.Contracts;
using JobSchedulerDemo.Application.Contracts.Infrastructure;

namespace JobSchedulerDemo.Application.Jobs;
public class Invoice : JobBase, IJob
{
  public Invoice(IPushMessageSender pushMessageSender) : base(pushMessageSender)
  {

  }

  public async Task Run(PerformContext? context)
  {
    await Run(nameof(Invoice), context);
  }
}

