using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.MessageContracts.MQ;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobSchedulerDemo.ClientUI.Server.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class JobsController : ControllerBase
  {
    private readonly IJobPublisher _publishEndPoint;
    private readonly IMediator _mediator;

    public JobsController(IJobPublisher publishEndPoint, IMediator mediator)
    {
      _publishEndPoint = publishEndPoint;
      _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Post(JobMessage jobMessage)
    {
      var request = new CreateScheduledJobCommand();
      request.ScheduledJobDto = new() { Name = jobMessage.Name };
      var scheduledJobDto = await _mediator.Send(request);

      // Should publish the job to queue in the mediator handle method

      jobMessage = new JobMessage(scheduledJobDto?.ScheduledJobDto?.Id.ToString() ?? "Invalid jobId", jobMessage.Name);

      _publishEndPoint.Publish(jobMessage);
      return Created("", jobMessage);
    }
  }
}
