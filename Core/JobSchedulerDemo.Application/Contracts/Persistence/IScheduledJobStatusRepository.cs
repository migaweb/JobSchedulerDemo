using JobSchedulerDemo.Domain;

namespace JobSchedulerDemo.Application.Contracts.Persistence;

public interface IScheduledJobStatusRepository : IGenericRepository<ScheduledJobStatus>
{
}
