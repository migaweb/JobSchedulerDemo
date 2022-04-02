using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.MessageContracts.MQ;
using MassTransit;

namespace JobSchedulerDemo.Infrastructure
{
  public class JobPublisher : IJobPublisher
  {
    private readonly IPublishEndpoint _publishEndPoint;

    public JobPublisher(IPublishEndpoint publishEndPoint)
    {
      _publishEndPoint = publishEndPoint;
    }

    public void Publish(JobMessage jobMessage)
    {
      _publishEndPoint.Publish(jobMessage);
    }
  }
}
