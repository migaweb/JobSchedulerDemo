using JobSchedulerDemo.Application.MessageContracts.Hub;
using JobSchedulerDemo.SignalRHub.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JobSchedulerDemo.SignalRHub.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PushMessageController : ControllerBase
  {
    private readonly IHubContext<PushMessageHub> _hubContext;
    private readonly ILogger<PushMessageController> _logger;

    public PushMessageController(IHubContext<PushMessageHub> hubContext, ILogger<PushMessageController> logger)
    {
      _hubContext = hubContext;
      _logger = logger;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> SendMessage([FromBody]PushMessage pushMessage)
    {
      await _hubContext.Clients.All.SendAsync("ReceiveMessage", pushMessage);

      var message = $"Push message {pushMessage} sent to all clients.";
      _logger.LogInformation(message);

      return Ok(message);
    }
  }
}