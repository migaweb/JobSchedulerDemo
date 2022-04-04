using Coravel.Pro.EntityFramework;
using JobSchedulerDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobSchedulerDemo.Persistence;

public class ScheduledJobsDbContext : AuditableDbcontext, ICoravelProDbContext
{
  public ScheduledJobsDbContext(DbContextOptions<ScheduledJobsDbContext> options)
      : base(options) { }

#nullable disable
  public DbSet<ScheduledJob> ScheduledJobs { get; set; }
  public DbSet<ScheduledJobStatus> ScheduledJobStatuses { get; set; }

  public DbSet<CoravelJobHistory> Coravel_JobHistory { get; set; }
  public DbSet<CoravelScheduledJob> Coravel_ScheduledJobs { get; set; }
  public DbSet<CoravelScheduledJobHistory> Coravel_ScheduledJobHistory { get; set; }
#nullable restore

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduledJobsDbContext).Assembly);
  }
}