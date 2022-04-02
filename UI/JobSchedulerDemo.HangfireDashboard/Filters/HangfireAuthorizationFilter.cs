using Hangfire.Dashboard;

namespace JobSchedulerDemo.HangfireDashboard.Filters;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
  public bool Authorize(DashboardContext context) => true;
}
