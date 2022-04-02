using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.Features.ScheduledJob.Responses;
using MediatR;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands
{
  public class CreateScheduledJobCommand : IRequest<CreateScheduledJobResponse>
  {
    public CreateScheduledJobDto? ScheduledJobDto { get; set; }
  }
}
