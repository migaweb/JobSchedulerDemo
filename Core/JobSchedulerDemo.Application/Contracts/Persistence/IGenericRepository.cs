using JobSchedulerDemo.Domain.Common;

namespace JobSchedulerDemo.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseDomainEntity
{
  Task<T?> GetAsync(int id);
  Task<IReadOnlyList<T>> GetAllAsync();
  Task<T> AddAsync(T entity);
  Task UpdateAsync(T entity);
  Task DeleteAsync(T entity);
  Task<bool> ExistsAsync(int id);
}
