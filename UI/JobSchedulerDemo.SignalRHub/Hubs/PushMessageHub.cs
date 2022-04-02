using Microsoft.AspNetCore.SignalR;

namespace JobSchedulerDemo.SignalRHub.Hubs
{
  public class PushMessageHub : Hub
  {
    public async Task SendMessage(string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", message);
    }
  }
}
