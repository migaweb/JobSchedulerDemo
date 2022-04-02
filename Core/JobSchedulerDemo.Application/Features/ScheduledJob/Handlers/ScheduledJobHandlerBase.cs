using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Persistence;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers;

public abstract class ScheduledJobHandlerBase
{
  protected readonly IScheduledJobRepository _scheduledJobRepository;
  protected readonly IMapper _mapper;

  public ScheduledJobHandlerBase(IScheduledJobRepository scheduledJobRepository, IMapper mapper)
  {
    _scheduledJobRepository = scheduledJobRepository;
    _mapper = mapper;
  }
}

