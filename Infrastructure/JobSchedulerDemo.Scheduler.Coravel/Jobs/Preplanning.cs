using Coravel.Invocable;
using MediatR;

namespace JobSchedulerDemo.Application.Jobs;
public class Preplanning : JobBase, IInvocable, IInvocableWithPayload<string>
{
  public Preplanning(IMediator mediator) : base(mediator)
  {

  }

  public string Payload { get; set; } = default!;

  public async Task Invoke()
  {
    await Run(Payload);
  }
}
