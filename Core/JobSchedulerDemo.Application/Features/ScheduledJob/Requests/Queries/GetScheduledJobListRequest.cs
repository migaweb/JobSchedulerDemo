using JobSchedulerDemo.Application.Dtos;
using MediatR;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Queries;

public class GetScheduledJobListRequest : IRequest<List<ScheduledJobDto>>
{
  public DateTime? MaxDateTime { get; set; }
}
