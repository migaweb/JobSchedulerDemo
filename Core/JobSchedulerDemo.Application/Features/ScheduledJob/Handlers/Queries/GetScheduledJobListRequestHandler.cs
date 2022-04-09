using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Queries;
using MediatR;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers.Queries
{
  public class GetScheduledJobListRequestHandler
  : ScheduledJobHandlerBase,
  IRequestHandler<GetScheduledJobListRequest, List<ScheduledJobDto>>
  {
    public GetScheduledJobListRequestHandler(IScheduledJobRepository scheduledJobRepository, IPushMessageSender pushMessageSender, IMapper mapper)
      : base(scheduledJobRepository, pushMessageSender, mapper) 
    {
    }

    public async Task<List<ScheduledJobDto>> Handle(GetScheduledJobListRequest request, CancellationToken cancellationToken)
    {
      var scheduledJobs = await _scheduledJobRepository.GetByMaxCreatedDateAsync(request.MaxDateTime);

      return _mapper.Map<List<ScheduledJobDto>>(scheduledJobs);
    }
  }
}
