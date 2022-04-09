using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using JobSchedulerDemo.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers.Commands
{
  public class RunScheduledJobCommandHandler : ScheduledJobHandlerBase, IRequestHandler<RunScheduledJobCommand, RunScheduledJobResponse>
  {
    private readonly ILogger<RunScheduledJobCommandHandler> _logger;

    public RunScheduledJobCommandHandler(
      IScheduledJobRepository scheduledJobRepository, IPushMessageSender pushMessageSender, IMapper mapper,
      ILogger<RunScheduledJobCommandHandler> logger)
      : base(scheduledJobRepository, pushMessageSender, mapper)
    {
      _logger = logger;
    }

    public async Task<RunScheduledJobResponse> Handle(RunScheduledJobCommand request, CancellationToken cancellationToken)
    {
      var response = new RunScheduledJobResponse();
      var job = await _scheduledJobRepository.GetByJobIdAsync(request.JobId);

      if (job == null)
        return response;

      if (!HasValidStatus(job))
      {
        return response;
      }

      job.Started = DateTime.Now;
      job.StatusId = (int)ScheduledJobStatusEnum.Running;

      await _scheduledJobRepository.UpdateAsync(job);

      int jobTime = new Random().Next(1, 50);

      PushStatus(job, $"started, run time {jobTime} s");
      if (await CheckIfCanceled(job, cancellationToken)) return response;

      await Task.Delay((jobTime * 1000) / 4, cancellationToken);
      PushStatus(job, $"25% running, time left {jobTime * 0.75m} s");
      if (await CheckIfCanceled(job, cancellationToken)) return response;
      await Task.Delay((jobTime * 1000) / 4, cancellationToken);
      PushStatus(job, $"50% running, time left {jobTime * 0.5m} s");
      if (await CheckIfCanceled(job, cancellationToken)) return response;
      await Task.Delay((jobTime * 1000) / 4, cancellationToken);
      PushStatus(job, $"75% running, time left {jobTime * 0.25m} s");
      if (await CheckIfCanceled(job, cancellationToken)) return response;
      await Task.Delay((jobTime * 1000) / 4, cancellationToken);

      job.Completed = DateTime.Now;
      job.StatusId = (int)ScheduledJobStatusEnum.Completed;

      await _scheduledJobRepository.UpdateAsync(job);

      PushStatus(job, ScheduledJobStatusEnum.Completed);

      response.ScheduledJobDto = _mapper.Map<ScheduledJobDto>(job);

      return response;
    }

    private bool HasValidStatus(Domain.ScheduledJob job)
    {
      if (job.StatusId != (int)ScheduledJobStatusEnum.Scheduled)
      {
        _logger.LogWarning("ScheduledJob with jobId {request.JobId} is not valid to run in state: {job.Status.Status}", job.JobId, job.Status.Status);
        return false;
      }

      return true;
    }

    private async Task<bool> CheckIfCanceled(Domain.ScheduledJob job, CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
      {
        PushStatus(job, "IsCancellationRequested");

        job.Started = DateTime.Now;
        job.StatusId = (int)ScheduledJobStatusEnum.Canceled;
        job.Error = "The job was canceled by user.";

        await _scheduledJobRepository.UpdateAsync(job);

        PushStatus(job, ScheduledJobStatusEnum.Canceled);

        _logger.LogInformation("Job with jobId {jobId] has been cancled!", job.JobId);

        return true;
      }

      return false;
    }

    private void CancelRunningJob(Domain.ScheduledJob job)
    {
      PushStatus(job, "The job is being requested to cancel!!!!!!!");
    }
  }
}
