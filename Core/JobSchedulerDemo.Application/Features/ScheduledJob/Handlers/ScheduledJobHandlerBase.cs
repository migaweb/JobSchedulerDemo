using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;

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
}

