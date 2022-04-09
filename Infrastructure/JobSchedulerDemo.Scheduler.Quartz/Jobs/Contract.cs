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
    var jobId = context.JobDetail.JobDataMap.GetString("id");

    if (jobId != null)
      await Run(jobId);
  }

  public new async Task Run(string jobId)
  {
    await base.Run(jobId);
  }
}
