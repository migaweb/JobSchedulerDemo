
using JobSchedulerDemo.Application.Constants;
using JobSchedulerDemo.Application.Extensions;
using JobSchedulerDemo.Infrastructure.Configuration;
using JobSchedulerDemo.Persistence.Configurations;
using JobSchedulerDemo.Scheduler.Coravel.Configuration;
using JobSchedulerDemo.Scheduler.Hangfire.Configuration;
using JobSchedulerDemo.Scheduler.Immediate.Configuration;
using JobSchedulerDemo.Scheduler.Quartz.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

bool useAzureServiceBus = true;

if (useAzureServiceBus)
{
  builder.Services.ConfigureMassTransitJobConsumer(
  null,//builder.Configuration["RabbitMQHost"],
  builder.Configuration["AzureServiceBus"]
  );
}
else
{
  builder.Services.ConfigureMassTransitJobConsumer(
  builder.Configuration["RabbitMQHost"],
  null
  );
}

builder.Services.ConfigurePushMessages(builder.Configuration);

builder.Services.ConfigureApplicationServices();

//builder.Services.ConfigureCoravelSchedulerServices();
builder.Services.ConfigureHangfireSchedulerServices(builder.Configuration);
//builder.Services.ConfigureImmediateSchedulerServices();
//builder.Services.ConfigureQuartzSchedulerServices(builder.Configuration);

builder.Services.ConfigurePersistenceServices(builder.Configuration);

builder.Services.AddHealthChecks()
  .AddSqlServer(
        builder.Configuration.GetConnectionString("JobsDbConnectionString"), 
        healthQuery: "SELECT 1",
        name: "JobsDB",
        failureStatus: HealthStatus.Unhealthy)
  .ConfigureQuartzHealthChecks();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.MapHealthChecks(HealthCheckConstants.Url);

app.Run();
