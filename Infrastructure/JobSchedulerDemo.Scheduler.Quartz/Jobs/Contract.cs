﻿
using MediatR;
using Quartz;

namespace JobSchedulerDemo.Infrastructure.Scheduler.Quartz;
public class Contract : JobBase, IJob
{
  public Contract(IMediator mediator) : base(mediator)
  {
  }

  public async Task Execute(IJobExecutionContext context)
  {
   await Run(context.JobDetail.JobDataMap.GetString("id"));
  }

  public new async Task Run(string jobId)
  {
    await base.Run(jobId);
  }
}
