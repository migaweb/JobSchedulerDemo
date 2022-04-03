using Hangfire;
using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using JobSchedulerDemo.Application.Jobs;
using JobSchedulerDemo.Application.MessageContracts.Hub;
using JobSchedulerDemo.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers.Commands
{
  public class ScheduleScheduledJobCommandHandler : 
    IRequestHandler<ScheduleScheduledJobCommand, ScheduleScheduledJobResponse>
  {
    private readonly IScheduledJobRepository _scheduledJobRepository;
    private readonly IPushMessageSender _pushMessageSender;
    private readonly IMapper _mapper;
    private readonly ILogger<ScheduleScheduledJobCommandHandler> _logger;

    public ScheduleScheduledJobCommandHandler(
      IScheduledJobRepository scheduledJobRepository, IPushMessageSender pushMessageSender, IMapper mapper,
      ILogger<ScheduleScheduledJobCommandHandler> logger)
    {
      _scheduledJobRepository = scheduledJobRepository;
      _pushMessageSender = pushMessageSender;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<ScheduleScheduledJobResponse> Handle(ScheduleScheduledJobCommand request, CancellationToken cancellationToken)
    {
      var response = new ScheduleScheduledJobResponse();

      var scheduledJob = await _scheduledJobRepository.GetAsync(request.Id);

      if (scheduledJob == null)
        throw new Exception($"ScheduleJob with Id={request.Id} could not be found.");

      if (scheduledJob.StatusId != (int)ScheduledJobStatusEnum.Created)
      {
        _logger.LogError("Job with id {id} has already been scheduled.", scheduledJob.Id);
      }

      scheduledJob.JobId = ScheduleJob(scheduledJob.Name, 10);
      scheduledJob.Scheduled = DateTime.Now;
      scheduledJob.StatusId = (int)ScheduledJobStatusEnum.Scheduled;

      try
      {
        await _scheduledJobRepository.UpdateAsync(scheduledJob);
      }
      catch (Exception ex)
      {
        _logger.LogError("Job could not be updated in DB: {ScheduledJobId}, Exception: {ex}", scheduledJob.Id, ex.Message);
      }

      response.ScheduledJobDto = _mapper.Map<ScheduledJobDto>(scheduledJob);

      _pushMessageSender.SendStatus(new PushMessage(scheduledJob.JobId, scheduledJob.Name, $"Scheduled with JobId - {scheduledJob.JobId}", scheduledJob.Scheduled.Value));

      return response;
    }

    private bool CancelJob(string jobId)
    {
      return BackgroundJob.Delete(jobId);
    }

    private string ScheduleJob(string name, int timeInSeconds)
    {
      string jobId = string.Empty;

      switch (name)
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
          _logger.LogWarning("{Name} is an invalid job.", name);
          break;
      }

      return jobId;
    }
  }
}
