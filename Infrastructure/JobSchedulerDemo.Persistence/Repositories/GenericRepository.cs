using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace JobSchedulerDemo.Persistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDomainEntity
{
  private readonly ScheduledJobsDbContext _dbContext;

  public GenericRepository(ScheduledJobsDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<TEntity> AddAsync(TEntity entity)
  {
    await _dbContext.AddAsync(entity);
    await _dbContext.SaveChangesAsync();
    return entity;
  }

  public async Task DeleteAsync(TEntity entity)
  {
    _dbContext.Set<TEntity>().Remove(entity);
    await _dbContext.SaveChangesAsync();
  }

  public async Task<bool> ExistsAsync(int id)
  {
    var entity = await GetAsync(id);

    return entity != null;
  }

  public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    => await _dbContext.Set<TEntity>().ToListAsync();

  public async Task<TEntity?> GetAsync(int id)
    => await _dbContext.Set<TEntity>().FindAsync(id);

  public async Task UpdateAsync(TEntity entity)
  {
    _dbContext.Entry(entity).State = EntityState.Modified;
    await _dbContext.SaveChangesAsync();
  }
}
