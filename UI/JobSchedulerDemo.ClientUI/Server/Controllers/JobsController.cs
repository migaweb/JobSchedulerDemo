using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Commands;
using JobSchedulerDemo.Application.Features.ScheduledJob.Requests.Queries;
using JobSchedulerDemo.Application.MessageContracts.MQ;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobSchedulerDemo.ClientUI.Server.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class JobsController : ControllerBase
  {
    
    private readonly IMediator _mediator;

    public JobsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _mediator.Send(new GetScheduledJobListRequest()));
    }

    [HttpPost]
    public async Task<IActionResult> Post(JobMessage jobMessage)
    {
      var request = new CreateScheduledJobCommand();
      request.ScheduledJobDto = new() { Name = jobMessage.Name };
      var scheduledJobDto = await _mediator.Send(request);

      return Created("", scheduledJobDto);
    }
  }
}
