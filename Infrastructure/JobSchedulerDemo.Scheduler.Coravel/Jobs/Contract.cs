using Coravel.Invocable;
using Coravel.Queuing.Interfaces;
using MediatR;

namespace JobSchedulerDemo.Application.Jobs;
public class Contract : JobBase, ICancellableTask, IInvocable, IInvocableWithPayload<string>
{
  public Contract(IMediator mediator) : base(mediator)
  {
  }

  public string Payload { get; set; } = default!;
  public CancellationToken Token { get; set; }

  public async Task Invoke()
  {
    await Run(Payload);
  }
}
