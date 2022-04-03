using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Exceptions;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using JobSchedulerDemo.Application.MessageContracts.Hub;
using JobSchedulerDemo.Application.MessageContracts.MQ;
using JobSchedulerDemo.Application.Validators.ScheduledJob;
using JobSchedulerDemo.Domain.Enums;
using MediatR;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers.Commands
{
  public class CreateScheduledJobCommandHandler : ScheduledJobHandlerBase, 
    IRequestHandler<CreateScheduledJobCommand, CreateScheduledJobResponse>
  {
    private readonly IPushMessageSender _pushMessageSender;

    public CreateScheduledJobCommandHandler(IScheduledJobRepository scheduledJobRepository, IJobPublisher publishEndPoint, IMapper mapper, IPushMessageSender pushMessageSender)
      : base(scheduledJobRepository, publishEndPoint, mapper)  
    {
      _pushMessageSender = pushMessageSender;
    }

    public async Task<CreateScheduledJobResponse> Handle(CreateScheduledJobCommand request, CancellationToken cancellationToken)
    {
      var response = new CreateScheduledJobResponse();
      var validator = new CreateScheduledJobValidator();

      if (request.ScheduledJobDto == null)
        throw new Exception($"{nameof(Domain.ScheduledJob)} cannot be null.");

      var validationResult = await validator.ValidateAsync(request.ScheduledJobDto, cancellationToken);

      if (!validationResult.IsValid)
        throw new ValidationException(validationResult);

      var scheduledJob = _mapper.Map<Domain.ScheduledJob>(request.ScheduledJobDto);
      scheduledJob.StatusId = (int)ScheduledJobStatusEnum.Created;

      scheduledJob = await _scheduledJobRepository.AddAsync(scheduledJob);

      response.ScheduledJobDto = _mapper.Map<ScheduledJobDto>(scheduledJob);

      QueueJob(
      new JobMessage(response.ScheduledJobDto?.Id.ToString() ?? "Invalid jobId", response.ScheduledJobDto?.Name!));

      _pushMessageSender.SendStatus(
        new PushMessage(
          scheduledJob.Id,
          scheduledJob.Name,
          ScheduledJobStatusEnum.Created.ToString(),
          scheduledJob.DateCreated,
          scheduledJob.JobId, scheduledJob.Scheduled, scheduledJob.Started, scheduledJob.Completed, scheduledJob.Error));

      return response;
    }

    private void QueueJob(JobMessage jobMessage)
    {
      _publishEndPoint.Publish(jobMessage);
    }
  }
}
