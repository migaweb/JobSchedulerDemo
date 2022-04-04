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

      _logger.LogInformation("JobMessage scheduled: {jobMessage}", context.Message);
    }
  }
}
