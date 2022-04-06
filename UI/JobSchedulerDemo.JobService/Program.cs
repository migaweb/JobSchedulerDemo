
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

builder.Services.ConfigureMassTransitJobConsumer(builder.Configuration["RabbitMQHost"]);

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
        failureStatus: HealthStatus.Unhealthy);
//.AddRabbitMQ(
//             "amqps://guest:guest@rabbitmq:5672",
//             name: "RabbitMQ",
//             failureStatus: HealthStatus.Healthy,
//             timeout: TimeSpan.FromSeconds(1),
//             tags: new string[] { "services" });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.MapHealthChecks(HealthCheckConstants.Url);

app.Run();
