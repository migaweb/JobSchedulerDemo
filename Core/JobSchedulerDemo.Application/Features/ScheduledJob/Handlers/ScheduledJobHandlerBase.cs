using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers;

public abstract class ScheduledJobHandlerBase
{
  protected readonly IScheduledJobRepository _scheduledJobRepository;
  protected readonly IJobPublisher _publishEndPoint;
  protected readonly IMapper _mapper;

  public ScheduledJobHandlerBase(IScheduledJobRepository scheduledJobRepository, IJobPublisher publishEndPoint, IMapper mapper)
  {
    _scheduledJobRepository = scheduledJobRepository;
    _publishEndPoint = publishEndPoint;
    _mapper = mapper;
  }
}

