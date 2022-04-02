using JobSchedulerDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobSchedulerDemo.Persistence;

public class ScheduledJobsDbContext : AuditableDbcontext
{
  public ScheduledJobsDbContext(DbContextOptions<ScheduledJobsDbContext> options)
      : base(options) { }

#nullable disable
  public DbSet<ScheduledJob> ScheduledJobs { get; set; }
  public DbSet<ScheduledJobStatus> ScheduledJobStatuses { get; set; }
#nullable restore

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduledJobsDbContext).Assembly);
  }
}