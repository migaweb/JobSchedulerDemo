using JobSchedulerDemo.Application.Dtos;

namespace JobSchedulerDemo.Application.Features.ScheduledJob.Responses
{
  public abstract class ScheduledJobBaseResponse
  {
    public ScheduledJobDto? ScheduledJobDto { get; set; }
  }
}
