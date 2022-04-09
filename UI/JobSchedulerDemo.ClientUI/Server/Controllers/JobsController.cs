using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Contracts.Persistence;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobSchedulerDemo.ClientUI.Server.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class JobsController : ControllerBase
  {
    
    private readonly IMediator _mediator;
    private readonly IJobPublisher _publisher;

    public JobsController(IMediator mediator, IJobPublisher publisher)
    {
      _mediator = mediator;
      _publisher = publisher;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _mediator.Send(new GetScheduledJobListRequest()));
    }

    [HttpDelete("{jobId:int}")]
    public async Task<IActionResult> Delete(string jobId)
    {
      await Task.CompletedTask;
      _publisher.Publish(new Application.MessageContracts.MQ.JobMessage(jobId, "Cancel message", true));
      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post(JobSchedulerDemo.Application.MessageContracts.MQ.JobMessage jobMessage)
    {
      var request = new CreateScheduledJobCommand();
      request.ScheduledJobDto = new() { Name = jobMessage.Name };
      var scheduledJobDto = await _mediator.Send(request);

      return Created("", scheduledJobDto);
    }
  }
}
