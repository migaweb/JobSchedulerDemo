using JobSchedulerDemo.Domain.Common;

namespace JobSchedulerDemo.Domain;
public class ScheduledJobStatus : BaseDomainEntity
{
  public string Status { get; set; } = default!;
}
