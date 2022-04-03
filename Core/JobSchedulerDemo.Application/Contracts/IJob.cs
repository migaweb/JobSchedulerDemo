using Hangfire.Server;
using MediatR;

namespace JobSchedulerDemo.Application.Contracts;
public interface IJob
  {
    Task Run(PerformContext? context);
  }

