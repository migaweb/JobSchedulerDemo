using JobSchedulerDemo.Application.Contracts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulerDemo.Scheduler.Immediate.Configuration;

public static class ConfigureImmediate
{
  public static void ConfigureImmediateSchedulerServices(this IServiceCollection services)
  {
    services.AddScoped<IScheduler, ImmediateScheduler>();
  }
}
