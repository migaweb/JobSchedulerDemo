using AutoMapper;
using JobSchedulerDemo.Application.Constants;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Domain.Enums;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers;

public abstract class ScheduledJobHandlerBase
{
  protected readonly IScheduledJobRepository _scheduledJobRepository;
  protected readonly IPushMessageSender _pushMessageSender;
  protected readonly IMapper _mapper;

  public ScheduledJobHandlerBase(IScheduledJobRepository scheduledJobRepository, IPushMessageSender pushMessageSender, IMapper mapper)
  {
    _scheduledJobRepository = scheduledJobRepository;
    _pushMessageSender = pushMessageSender;
    _mapper = mapper;
  }

  protected void PushStatus(Domain.ScheduledJob job, ScheduledJobStatusEnum status)
  {
    PushStatus(job, status.ToString());
  }

  protected void PushStatus(Domain.ScheduledJob job, string status)
  {
    var instanceName = Environment.GetEnvironmentVariable(EnvironmentVariables.InstanceName);

    instanceName = String.IsNullOrEmpty(instanceName) ? String.Empty : $"({instanceName})";

    _pushMessageSender.SendStatus(
      new MessageContracts.Hub.PushMessage(
        job.Id,
        job.Name,
        $"{status} {instanceName}",
        job.DateCreated,
        job.JobId, job.Scheduled, job.Started, job.Completed, job.Error
        ));
  }
}

