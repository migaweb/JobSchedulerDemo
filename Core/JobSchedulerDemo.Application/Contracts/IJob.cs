using Hangfire.Server;

namespace JobSchedulerDemo.Application.Contracts;
public interface IJob
  {
    Task Run(PerformContext? context);
  }

