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
    public PushMessage? PushMessage { get; set; }
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
        Console.WriteLine("Message received!");

        PushMessage = message;

        var scheduledJob = ScheduledJobs?.FirstOrDefault(e => e.Id == message.Id);

        if (scheduledJob != null)
        {
          scheduledJob.Error = message.Error;
          scheduledJob.Status.Status = message.Status;
          scheduledJob.Scheduled = message.Scheduled;
          scheduledJob.Started = message.Started;
          scheduledJob.Completed = message.Completed;
          scheduledJob.JobId = message.JobId ?? "";
          scheduledJob.Name = message.Name;
        }
        else
        {
          ScheduledJobs?.Add(new ScheduledJobDto { 
            Error = message.Error,
            Completed = message.Completed,
            Id = message.Id,
            JobId = message.JobId ?? "",
            Name = message.Name,
            Status = new ScheduledJobStatusDto { Id = 1, Status = message.Status },
            Scheduled = message.Scheduled,
            Started = message.Started,
          });
        }

        StateHasChanged();
      });

      try
      {
        await _hubConnection.StartAsync();
      }
      catch (Exception ex) { Console.WriteLine("Exception: {0}", ex.Message); }

    }

    private async Task CancelJob(string jobId)
    {
      await HttpClient.DeleteAsync($"/Jobs/{jobId}");
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
