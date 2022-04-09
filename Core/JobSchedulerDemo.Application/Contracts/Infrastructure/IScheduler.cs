namespace JobSchedulerDemo.Application.Contracts.Infrastructure
{
    public interface IScheduler
  {
    Task<string?> Schedule(string type, int jobId, int timeInSeconds);
    Task<bool> Cancel(string jobId);
  }
}
