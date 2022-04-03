using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Application.MessageContracts.Hub;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace JobSchedulerDemo.ClientUI.Client.Pages
{
  public partial class Index : ComponentBase, IAsyncDisposable
  {
    [Inject] public HttpClient HttpClient { get; set; } = default!;
    public List<PushMessage> Messages { get; set; } = new();
    public List<ScheduledJobDto>? ScheduledJobs { get; set; } = new();
    public bool IsConnected => _hubConnection?.State == HubConnectionState.Connected;

    private HubConnection? _hubConnection;

    protected override async Task OnInitializedAsync()
    {
      var response = await HttpClient.GetAsync("/Jobs");

      if (response.IsSuccessStatusCode)
        ScheduledJobs = await response.Content.ReadFromJsonAsync<List<ScheduledJobDto>>();

      _hubConnection = new HubConnectionBuilder()
        .WithUrl("http://localhost:8003/pushmessagehub").Build();
      Console.WriteLine("Starting hub at: {0}", "https://localhost:8003/pushmessagehub");

      _hubConnection.On<PushMessage>("ReceiveMessage", (message) => {
        var msg = Messages.Where(e => e.Id == message.Id).FirstOrDefault();
        Console.WriteLine(message);
        if (msg == null)
          Messages.Add(message);
        else
        {
          Messages.Remove(msg);
          Messages.Add(message);
        }

        StateHasChanged();
      });

      try
      {
        await _hubConnection.StartAsync();
      }
      catch (Exception ex) { Console.WriteLine("Exception: {0}", ex.Message); }

    }

    public async ValueTask DisposeAsync()
    {
      if (_hubConnection is not null)
      {
        await _hubConnection.DisposeAsync();
      }

      GC.SuppressFinalize(this);
    }
  }
}
