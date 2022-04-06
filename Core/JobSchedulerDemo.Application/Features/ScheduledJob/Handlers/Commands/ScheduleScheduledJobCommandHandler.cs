
using AutoMapper;
using JobSchedulerDemo.Application.Constants;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
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
    private readonly IScheduler _scheduler;

    public ScheduleScheduledJobCommandHandler(
      IScheduledJobRepository scheduledJobRepository, IPushMessageSender pushMessageSender, IMapper mapper,
      ILogger<ScheduleScheduledJobCommandHandler> logger,
      IScheduler scheduler)
    {
      _scheduledJobRepository = scheduledJobRepository;
      _pushMessageSender = pushMessageSender;
      _mapper = mapper;
      _logger = logger;
      _scheduler = scheduler;
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

      scheduledJob.JobId = await _scheduler.Schedule(scheduledJob.Name, scheduledJob.Id, 5);
      scheduledJob.Scheduled = DateTime.Now;
      scheduledJob.StatusId = (int)ScheduledJobStatusEnum.Scheduled;

      if (String.IsNullOrEmpty(scheduledJob.JobId))
      {
        scheduledJob.StatusId = (int)ScheduledJobStatusEnum.Rejected;
        scheduledJob.Error = $"Unknown job: {scheduledJob.JobId}";
        scheduledJob.Completed = scheduledJob.Scheduled;
      }

      try
      {
        await _scheduledJobRepository.UpdateAsync(scheduledJob);
      }
      catch (Exception ex)
      {
        await CancelJob(scheduledJob.Id);
        _logger.LogError("Job could not be updated in DB: {ScheduledJobId}, Exception: {ex}", scheduledJob.Id, ex.Message);
      }

      response.ScheduledJobDto = _mapper.Map<ScheduledJobDto>(scheduledJob);

      var instanceName = Environment.GetEnvironmentVariable(EnvironmentVariables.InstanceName);
        string status = string.IsNullOrEmpty(scheduledJob.JobId) ? ScheduledJobStatusEnum.Rejected.ToString() : ScheduledJobStatusEnum.Scheduled.ToString();

      _pushMessageSender.SendStatus(
        new PushMessage(
          scheduledJob.Id,
          scheduledJob.Name,
          $"{status} ({instanceName})",
          scheduledJob.Scheduled.Value,
          scheduledJob.JobId, scheduledJob.Scheduled, scheduledJob.Started, scheduledJob.Completed, scheduledJob.Error
          ));

      return response;
    }

    private async Task<bool> CancelJob(int id)
    {
      return await _scheduler.Cancel(id);
    }
  }
}
