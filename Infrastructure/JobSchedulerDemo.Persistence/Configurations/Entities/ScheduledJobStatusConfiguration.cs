using JobSchedulerDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSchedulerDemo.Persistence.Configurations.Entities;
public class ScheduledJobStatusConfiguration : IEntityTypeConfiguration<ScheduledJobStatus>
{
  public void Configure(EntityTypeBuilder<ScheduledJobStatus> builder)
  {
    var dateNow = DateTime.UtcNow;
    builder.HasData(
      new ScheduledJobStatus
      {
        CreatedBy = "Initial Create",
        DateCreated = dateNow,
        Id = 1,
        LastModifiedBy = "Initial Create",
        LastModifiedDate = dateNow,
        Status = "Created"
      },
      new ScheduledJobStatus
      {
        CreatedBy = "Initial Create",
        DateCreated = dateNow,
        Id = 2,
        LastModifiedBy = "Initial Create",
        LastModifiedDate = dateNow,
        Status = "Scheduled"
      },
      new ScheduledJobStatus
      {
        CreatedBy = "Initial Create",
        DateCreated = dateNow,
        Id = 3,
        LastModifiedBy = "Initial Create",
        LastModifiedDate = dateNow,
        Status = "Running"
      },
      new ScheduledJobStatus
      {
        CreatedBy = "Initial Create",
        DateCreated = dateNow,
        Id = 4,
        LastModifiedBy = "Initial Create",
        LastModifiedDate = dateNow,
        Status = "Completed"
      },
      new ScheduledJobStatus
      {
        CreatedBy = "Initial Create",
        DateCreated = dateNow,
        Id = 5,
        LastModifiedBy = "Initial Create",
        LastModifiedDate = dateNow,
        Status = "Error"
      },
      new ScheduledJobStatus
      {
        CreatedBy = "Initial Create",
        DateCreated = dateNow,
        Id = 6,
        LastModifiedBy = "Initial Create",
        LastModifiedDate = dateNow,
        Status = "Rejected"
      },
      new ScheduledJobStatus
      {
        CreatedBy = "Initial Create",
        DateCreated = dateNow,
        Id = 7,
        LastModifiedBy = "Initial Create",
        LastModifiedDate = dateNow,
        Status = "Cancelling"
      },
      new ScheduledJobStatus
      {
        CreatedBy = "Initial Create",
        DateCreated = dateNow,
        Id = 8,
        LastModifiedBy = "Initial Create",
        LastModifiedDate = dateNow,
        Status = "Cenceled"
      }
    );
  }
}

