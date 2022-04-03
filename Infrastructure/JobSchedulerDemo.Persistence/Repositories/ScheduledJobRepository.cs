using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobSchedulerDemo.Persistence.Repositories
{
  internal class ScheduledJobRepository : GenericRepository<ScheduledJob>, IScheduledJobRepository
  {
    private readonly ScheduledJobsDbContext _dbContext;

    public ScheduledJobRepository(ScheduledJobsDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<ScheduledJob>> GetAllWithDetailsAsync() 
      => await _dbContext.ScheduledJobs.Include(e => e.Status).ToListAsync();

    public async Task<IEnumerable<ScheduledJob>> GetByMaxCreatedDateAsync(DateTime? maxCreatedDate)
    => await _dbContext.ScheduledJobs.Include(e => e.Status)
                                     .Where(e => !maxCreatedDate.HasValue || e.DateCreated >= maxCreatedDate)
                                     .ToListAsync();

    public async Task<ScheduledJob?> GetByJobIdAsync(string jobId)
      => await _dbContext.ScheduledJobs.Include(e => e.Status)
                                       .Where(e => e.JobId == jobId)
                                       .FirstOrDefaultAsync();
  }
}
