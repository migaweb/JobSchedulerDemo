using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.MessageContracts.Hub;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace JobSchedulerDemo.Infrastructure;
public class PushMessageSender : IPushMessageSender
{
  private readonly IHttpClientFactory _httpClientFactory;
  private readonly ILogger<PushMessageSender> _logger;

  public PushMessageSender(IHttpClientFactory httpClientFactory, ILogger<PushMessageSender> logger)
  {
    _httpClientFactory = httpClientFactory;
    _logger = logger;
  }

  public void SendStatus(PushMessage pushMessage)
  {
    var httpClient = GetClient();

    try
    {
      _ = httpClient.PostAsJsonAsync("api/pushmessage/SendMessage", pushMessage);
    }
    catch (Exception ex)
    {
      _logger.LogWarning("Could not send pushmessage: {pushMessage}, Exception={ex}", pushMessage, ex);
    }
  }

  private HttpClient GetClient()
  {
    return _httpClientFactory.CreateClient("PushMessages");
  }
}
