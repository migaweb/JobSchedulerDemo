using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Exceptions;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using JobSchedulerDemo.Application.Validators.ScheduledJob;
using JobSchedulerDemo.Domain;
using JobSchedulerDemo.Domain.Enums;
using MediatR;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers.Commands
{
  public class CreateScheduledJobCommandHandler : ScheduledJobHandlerBase, 
    IRequestHandler<CreateScheduledJobCommand, CreateScheduledJobResponse>
  {
    public CreateScheduledJobCommandHandler(IScheduledJobRepository scheduledJobRepository, IMapper mapper)
      : base(scheduledJobRepository, mapper)  
    {
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

      return response;
    }
  }
}
