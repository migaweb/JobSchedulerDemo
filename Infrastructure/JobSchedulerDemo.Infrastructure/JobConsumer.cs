using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.MessageContracts.MQ;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JobSchedulerDemo.Infrastructure
{
  public class JobConsumer : IConsumer<JobMessage>
  {
    private readonly IMediator _mediator;
    private readonly ILogger<JobConsumer> _logger;

    public JobConsumer(IMediator mediator, ILogger<JobConsumer> logger)
    {
      _mediator = mediator;
      _logger = logger;
    }

    public async Task Consume(ConsumeContext<JobMessage> context)
    {
      _logger.LogInformation("JobMessage received: {jobMessage}", context.Message);

      await _mediator.Send(new ScheduleScheduledJobCommand
      {
        Id = Int32.Parse(context.Message.Id),
        Name = context.Message.Name,
      });

      // Note, if using immediate job scheduling
      // masstransit will not send ack to MQ until this method returns.

      // When using Immediate scheduling uncomment this line.
      // Would be nice with some other architecture for this.
      //await _mediator.Send(new RunScheduledJobCommand
      //{
      //  JobId = context.Message.Id
      //});

      _logger.LogInformation("JobMessage scheduled: {jobMessage}", context.Message);
    }
  }
}
