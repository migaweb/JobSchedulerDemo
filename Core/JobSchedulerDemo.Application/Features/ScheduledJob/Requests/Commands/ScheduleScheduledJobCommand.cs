using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using MediatR;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands
{
  public class ScheduleScheduledJobCommand : IRequest<ScheduleScheduledJobResponse>
  {
    public int Id { get; set; } = default!;
    public string Name { get; set; } = default!;

  }
}
