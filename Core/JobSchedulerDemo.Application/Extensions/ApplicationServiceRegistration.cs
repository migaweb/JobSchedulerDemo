using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JobSchedulerDemo.Application.Extensions;

public static class ApplicationServiceRegistration
{
  public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
  {
    services.AddAutoMapper(Assembly.GetExecutingAssembly());

    services.AddMediatR(Assembly.GetExecutingAssembly());

    return services;
  }
}