using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using MediatR;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands
{
  public class RunScheduledJobCommand: IRequest<RunScheduledJobResponse>
  {
    public string JobId { get; set; } = default!;
  }
}
