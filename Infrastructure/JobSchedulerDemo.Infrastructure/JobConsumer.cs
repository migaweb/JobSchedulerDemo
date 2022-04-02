using Hangfire;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Jobs;
using JobSchedulerDemo.Application.MessageContracts.Hub;
using JobSchedulerDemo.Application.MessageContracts.MQ;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace JobSchedulerDemo.Infrastructure
{
  public class JobConsumer : IConsumer<JobMessage>
  {
    private readonly IPushMessageSender _pushMessageSender;
    private readonly ILogger<JobConsumer> _logger;

    public JobConsumer(IPushMessageSender pushMessageSender, ILogger<JobConsumer> logger)
    {
      _pushMessageSender = pushMessageSender;
      _logger = logger;
    }

    public async Task Consume(ConsumeContext<JobMessage> context)
    {
      int timeInSeconds = 5;
      string jobId = string.Empty;

      switch (context.Message.Name)
      {
        case nameof(Preplanning):
          var preplanning = new Preplanning(_pushMessageSender);
          jobId = BackgroundJob.Schedule(() => preplanning.Run(null), TimeSpan.FromSeconds(timeInSeconds));
          break;

        case nameof(Contract):
          var contract = new Contract(_pushMessageSender);
          jobId = BackgroundJob.Schedule(() => contract.Run(null), TimeSpan.FromSeconds(timeInSeconds));
          break;

        case nameof(Invoice):
          var invoice = new Invoice(_pushMessageSender);
          jobId = BackgroundJob.Schedule(() => invoice.Run(null), TimeSpan.FromSeconds(timeInSeconds));
          break;
        default:
          _logger.LogWarning("{Name} is an invalid job. Details={Message}", context.Message.Name, context.Message);
          goto NoJob;
      }

      _pushMessageSender.SendStatus(new PushMessage(jobId, context.Message.Name, $"Scheduled with JobId - {jobId}", DateTime.Now));
      _logger.LogInformation("Job ID: {jobId}. Job {Message} scheduled in {timeInSeconds} seconds.", jobId, context.Message, timeInSeconds);

    NoJob:
      await Task.CompletedTask;
    }
  }
}
