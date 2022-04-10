using JobSchedulerDemo.Domain;

namespace JobSchedulerDemo.Application.Contracts.Persistence;

public interface IScheduledJobRepository : IGenericRepository<ScheduledJob>
{
  Task<IEnumerable<ScheduledJob>> GetAllWithDetailsAsync();
  Task<IEnumerable<ScheduledJob>> GetByMaxCreatedDateAsync(DateTime? maxCreatedDate);
  Task<ScheduledJob?> GetByJobIdAsync(string jobId);
  Task<ScheduledJob?> GetByJobByIdNoTrackingAsync(int id);

}
