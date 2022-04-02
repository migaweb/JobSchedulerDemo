using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.MessageContracts.MQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSchedulerDemo.ClientUI.Server.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class JobsController : ControllerBase
  {
    private readonly IJobPublisher _publishEndPoint;

    public JobsController(IJobPublisher publishEndPoint)
    {
      _publishEndPoint = publishEndPoint;
    }
    [HttpPost]
    public IActionResult Post(JobMessage jobMessage)
    {
      _publishEndPoint.Publish(jobMessage);
      return Created("", jobMessage);
    }
  }
}
