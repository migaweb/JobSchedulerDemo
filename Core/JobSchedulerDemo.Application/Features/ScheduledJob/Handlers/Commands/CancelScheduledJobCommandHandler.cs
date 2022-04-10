using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using JobSchedulerDemo.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers.Commands;
public class CancelScheduledJobCommandHandler : ScheduledJobHandlerBase,
    IRequestHandler<CancelScheduledJobCommand, CancelScheduledJobResponse>
{
  private readonly IScheduler _scheduler;
  private readonly ILogger<CancelScheduledJobCommandHandler> _logger;

  public CancelScheduledJobCommandHandler(
    IScheduledJobRepository scheduledJobRepository, IMapper mapper, IPushMessageSender pushMessageSender,
    IScheduler scheduler, ILogger<CancelScheduledJobCommandHandler> logger)
      : base(scheduledJobRepository, pushMessageSender, mapper)
  {
    _scheduler = scheduler;
    _logger = logger;
  }

  public async Task<CancelScheduledJobResponse> Handle(CancelScheduledJobCommand request, CancellationToken cancellationToken)
  {
    var response = new CancelScheduledJobResponse();
    var job = await GetJob(request);
    
    if (!HasValidStatus(request, job))
    {
      response.ScheduledJobDto = _mapper.Map<ScheduledJobDto>(job);
      return response;
    }

    var oldStatus = (ScheduledJobStatusEnum)job.StatusId;

    if (oldStatus == ScheduledJobStatusEnum.Running)
    {
      // Running job will be notified and perform graceful cancellation
      // Have to handle race condition, the job might just be started!!!!!
      await UpdateStatus(job, ScheduledJobStatusEnum.Cancelling, "Cancelling requested");
      PushStatus(job, ScheduledJobStatusEnum.Cancelling);
    }
    else
    {
      await UpdateStatus(job, ScheduledJobStatusEnum.Canceled, "Job canceled by user.");
      PushStatus(job, ScheduledJobStatusEnum.Canceled);
    }

    if (job.JobId != null)
    {
      var canceled = await _scheduler.Cancel(job.JobId);

      if (!canceled)
      {
        await UpdateStatus(job, oldStatus, "Scheduler could not cancel.");
        PushStatus(job, "Could not cancel");
      }
    }
    else
    {
      await UpdateStatus(job, oldStatus, "Job does not have a job id.");
      PushStatus(job, $"Invalid job id");
      return response;
    }

    response.ScheduledJobDto = _mapper.Map<ScheduledJobDto>(job);

    return response;
  }

  private async Task UpdateStatus(Domain.ScheduledJob job, ScheduledJobStatusEnum status, string message)
  {
    job.StatusId = (int)status;
    job.Error = message;

    await _scheduledJobRepository.UpdateAsync(job);
  }

  private bool HasValidStatus(CancelScheduledJobCommand request, Domain.ScheduledJob? job)
  {
    if (job == null) return false;
    if (job.StatusId == (int)ScheduledJobStatusEnum.Completed ||
        job.StatusId == (int)ScheduledJobStatusEnum.Cancelling ||
        job.StatusId == (int)ScheduledJobStatusEnum.Canceled)
    {
      PushStatus(job, $"Cannot cancel, wrong status");

      _logger.LogWarning("ScheduledJob with jobId {request.JobId} is not valid to cancel in state: {job.Status.Status}", request.JobId, job.Status.Status);

      return false;
    }

    return true;
  }

  private async Task<Domain.ScheduledJob?> GetJob(CancelScheduledJobCommand request)
  {
    var job = await _scheduledJobRepository.GetByJobIdAsync(request.JobId);

    if (job == null)
      _logger.LogWarning("ScheduledJob with jobId {request.JobId} was not found.", request.JobId);

    return job;
  }
}

