using JobSchedulerDemo.Domain.Common;

namespace JobSchedulerDemo.Domain
{
  public class ScheduledJob : BaseDomainEntity
  {
    public string? JobId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public DateTime? Scheduled { get; set; }
    public DateTime? Started { get; set; }
    public DateTime? Completed { get; set; }

    public string? Error { get; set; }

    public int StatusId { get; set; }
    public ScheduledJobStatus Status { get; set; } = default!;
  }
}