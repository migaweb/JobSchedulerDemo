using JobSchedulerDemo.Application.MessageContracts.MQ;

namespace JobSchedulerDemo.Application.Contracts.Infrastructure
{
  public interface IJobConsumer
  {
    Task Consume(JobMessage jobMessage);
  }
}
