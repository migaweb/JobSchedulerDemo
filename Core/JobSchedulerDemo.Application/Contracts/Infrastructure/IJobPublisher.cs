using JobSchedulerDemo.Application.MessageContracts.MQ;

namespace JobSchedulerDemo.Application.Contracts.Infrastructure;
public interface IJobPublisher
{
  void Publish(JobMessage jobMessage);
}
