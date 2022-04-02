namespace JobSchedulerDemo.Application.Dtos
{
  public class ScheduledJobDto : BaseDto
  {
    public string JobId { get; set; }
    public string Name { get; set; }
    public DateTime? Scheduled { get; set; }
    public DateTime? Started { get; set; }
    public DateTime? Completed { get; set; }

    public string? Error { get; set; }

    public ScheduledJobStatusDto Status { get; set; }
  }
}
