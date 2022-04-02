using JobSchedulerDemo.Application.MessageContracts.Hub;

namespace JobSchedulerDemo.Application.Contracts.Infrastructure;
public interface IPushMessageSender
{
  void SendStatus(PushMessage pushMessage);
}
