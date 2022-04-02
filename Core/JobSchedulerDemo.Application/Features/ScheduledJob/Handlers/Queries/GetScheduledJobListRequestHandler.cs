using AutoMapper;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Handlers.Queries
{
  public class GetScheduledJobListRequestHandler
  : ScheduledJobHandlerBase,
  IRequestHandler<GetScheduledJobListRequest, List<ScheduledJobDto>>
  {
    public GetScheduledJobListRequestHandler(IScheduledJobRepository scheduledJobRepository, IMapper mapper)
      : base(scheduledJobRepository, mapper)
    {

    }

    public async Task<List<ScheduledJobDto>> Handle(GetScheduledJobListRequest request, CancellationToken cancellationToken)
    {
      var scheduledJobs = await _scheduledJobRepository.GetByMaxCreatedDateAsync(request.MaxDateTime);

      return _mapper.Map<List<ScheduledJobDto>>(scheduledJobs);
    }
  }
}
