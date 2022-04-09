using JobSchedulerDemo.Scheduler.Quartz.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedulerDemo.Scheduler.Quartz.Configuration
{
  public static class ConfigureHealthCheck
  {
    public static IHealthChecksBuilder ConfigureQuartzHealthChecks(this IHealthChecksBuilder builder)
    {
      builder.AddCheck<QuartzHealthCheck>("JobScheduler");
      return builder;
    }
  }
}
