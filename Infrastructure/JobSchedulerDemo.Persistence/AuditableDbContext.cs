using JobSchedulerDemo.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace JobSchedulerDemo.Persistence;

public abstract class AuditableDbcontext : DbContext
{
  public AuditableDbcontext(DbContextOptions options) : base(options) { }

  public virtual async Task<int> SaveChangesAsync(string username = "System")
  {
    var dateNow = DateTime.UtcNow;
    foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
      .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
    {
      entry.Entity.LastModifiedDate = dateNow;
      entry.Entity.LastModifiedBy = username;

      if (entry.State == EntityState.Added)
      {
        entry.Entity.DateCreated = dateNow;
        entry.Entity.CreatedBy = username;
      }
    }

    var result = await base.SaveChangesAsync();

    return result;
  }
}
