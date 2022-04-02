using JobSchedulerDemo.Application.Constants;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace JobSchedulerDemo.Infrastructure.Configuration;
public static class PushMessagesRegistration
{
  public static void ConfigurePushMessages(this IServiceCollection services, HostBuilderContext builder)
  {
    services.AddScoped<IPushMessageSender, PushMessageSender>();
    services.ConfigureHttpClientFactory(builder);
  }

  private static void ConfigureHttpClientFactory(this IServiceCollection services, HostBuilderContext builder)
  {
    services.AddHttpClient("PushMessages", httpClient =>
    {
      var pushMessageUrl = builder.Configuration["PushMessageUrl"];
      httpClient.BaseAddress = new Uri(pushMessageUrl);

      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Add(
          HeaderNames.Accept, PushMessageConstants.MediaType);
      httpClient.DefaultRequestHeaders.Add(
            HeaderNames.UserAgent, PushMessageConstants.UserAgent);
    });
  }
}

