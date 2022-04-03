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
  public class RunScheduledJobCommandHandler : IRequestHandler<RunScheduledJobCommand, RunScheduledJobResponse>
  {
    private readonly IScheduledJobRepository _scheduledJobRepository;
    private readonly IPushMessageSender _pushMessageSender;
    private readonly IMapper _mapper;
    private readonly ILogger<RunScheduledJobCommandHandler> _logger;

    public RunScheduledJobCommandHandler(
      IScheduledJobRepository scheduledJobRepository, IPushMessageSender pushMessageSender, IMapper mapper,
      ILogger<RunScheduledJobCommandHandler> logger)
    {
      _scheduledJobRepository = scheduledJobRepository;
      _pushMessageSender = pushMessageSender;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<RunScheduledJobResponse> Handle(RunScheduledJobCommand request, CancellationToken cancellationToken)
    {
      var response = new RunScheduledJobResponse();
      var job = await _scheduledJobRepository.GetByJobIdAsync(request.JobId);

      if (job == null)
        throw new Exception($"ScheduledJob with jobId {request.JobId} was not found.");

      if (job.StatusId != (int)ScheduledJobStatusEnum.Scheduled)
        throw new Exception($"ScheduledJob with jobId {request.JobId} is not valid to run in state: {job.Status.Status}");

      job.Started = DateTime.Now;
      job.StatusId = (int)ScheduledJobStatusEnum.Running;

      await _scheduledJobRepository.UpdateAsync(job);

      int jobTime = new Random().Next(1, 50);

      PushStatus(job, $"started, run time {jobTime} s");

      await Task.Delay((jobTime * 1000) / 4, cancellationToken);
      PushStatus(job, $"25% running, time left {jobTime * 0.75m} s");
      await Task.Delay((jobTime * 1000) / 4, cancellationToken);
      PushStatus(job, $"50% running, time left {jobTime * 0.5m} s");
      await Task.Delay((jobTime * 1000) / 4, cancellationToken);
      PushStatus(job, $"75% running, time left {jobTime * 0.25m} s");
      await Task.Delay((jobTime * 1000) / 4, cancellationToken);

      job.Completed = DateTime.Now;
      job.StatusId = (int)ScheduledJobStatusEnum.Completed;

      await _scheduledJobRepository.UpdateAsync(job);

      PushStatus(job, ScheduledJobStatusEnum.Completed.ToString());

      response.ScheduledJobDto = _mapper.Map<ScheduledJobDto>(job);

      return response;
    }

    private void PushStatus(Domain.ScheduledJob job, string status)
    {
      _pushMessageSender.SendStatus(
        new MessageContracts.Hub.PushMessage(
          job.Id,
          job.Name,
          status.ToString(),
          job.DateCreated,
          job.JobId, job.Scheduled, job.Started, job.Completed, job.Error
          ));
    }
  }
}
