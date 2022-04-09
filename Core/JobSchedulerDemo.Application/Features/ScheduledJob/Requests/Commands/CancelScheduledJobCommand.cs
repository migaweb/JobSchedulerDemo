using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using MediatR;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
public class CancelScheduledJobCommand : IRequest<CancelScheduledJobResponse>
{
  public string JobId { get; set; } = default!;
}

