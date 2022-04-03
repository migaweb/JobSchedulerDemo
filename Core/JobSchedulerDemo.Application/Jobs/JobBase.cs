using Hangfire.Server;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using MediatR;

namespace JobSchedulerDemo.Application.Jobs
{
  public abstract class JobBase
  {
    private readonly IMediator _mediator;

    public JobBase(IMediator mediator)
    {
      _mediator = mediator;
    }

    public async Task Run(PerformContext? context)
    {
      string id = context?.BackgroundJob?.Id ?? $"{DateTime.Now.Ticks}";
      await _mediator.Send(new RunScheduledJobCommand { JobId = id });
      

      //int jobTime = new Random().Next(1, 50);

      //PushStatus(id, job, $"started, run time {jobTime} s");

      //await Task.Delay((jobTime * 1000) / 4);
      //PushStatus(id, job, $"25% running, time left {jobTime * 0.75m} s");
      //await Task.Delay((jobTime * 1000) / 4);
      //PushStatus(id, job, $"50% running, time left {jobTime * 0.5m} s");
      //await Task.Delay((jobTime * 1000) / 4);
      //PushStatus(id, job, $"75% running, time left {jobTime * 0.25m} s");
      //await Task.Delay((jobTime * 1000) / 4);
      //PushStatus(id, job, $"finished");
    }

    //private void PushStatus(string id, string name, string status)
    //{
    //  _pushMessageSender.SendStatus(
    //    new MessageContracts.Hub.PushMessage(
    //      Int32.Parse(id), 
    //      name, 
    //      status, 
    //      DateTime.Now,
    //      null, null, null, null, null
    //      ));
    //}
  }
}
