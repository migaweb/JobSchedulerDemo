namespace JobSchedulerDemo.Application.Dtos
{
  public class ScheduledJobDto : BaseDto
  {
    public string JobId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public DateTime? Scheduled { get; set; }
    public DateTime? Started { get; set; }
    public DateTime? Completed { get; set; }

    public string? Error { get; set; }

    public ScheduledJobStatusDto Status { get; set; } = new ScheduledJobStatusDto();
  }
}
