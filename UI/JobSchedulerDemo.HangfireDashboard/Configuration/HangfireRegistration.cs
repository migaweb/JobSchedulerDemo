using Hangfire;
using JobSchedulerDemo.HangfireDashboard.Filters;

namespace JobSchedulerDemo.HangfireDashboard.Configuration
{
  public static class HangfireRegistration
  {
    public static IApplicationBuilder UseHangfireDashboard(this IApplicationBuilder app)
    {
      var options = new DashboardOptions()
      {
        Authorization = new[] { new HangfireAuthorizationFilter() }
      };

      app.UseHangfireDashboard("/hangfire", options);

      return app;
    }

    public static void ConfigureHangfire(this WebApplicationBuilder builder)
    {
      builder.Services.AddHangfire(x => x.UseSqlServerStorage(GetHangfireConnectionString(builder)));
    }

    private static string GetHangfireConnectionString(WebApplicationBuilder builder)
    {
      string dbName = builder.Configuration["HangfireDatabaseName"];
      string connectionStringFormat = builder.Configuration.GetConnectionString("HangfireDB");

      using (var connection = new System.Data.SqlClient.SqlConnection(string.Format(connectionStringFormat, "master")))
      {
        connection.Open();

        using (var command = new System.Data.SqlClient.SqlCommand(string.Format(
            @"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}') 
                                    create database [{0}];
                      ", dbName), connection))
        {
          command.ExecuteNonQuery();
        }
      }

      return string.Format(connectionStringFormat, dbName);
    }
  }
}
