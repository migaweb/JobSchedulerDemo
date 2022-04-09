using Coravel.Pro;
using JobSchedulerDemo.Application.Contracts.Infrastructure;
using JobSchedulerDemo.Application.Extensions;
using JobSchedulerDemo.Infrastructure.Configuration;
using JobSchedulerDemo.Infrastructure.Scheduler.Quartz;
using JobSchedulerDemo.Persistence.Configurations;
using JobSchedulerDemo.Scheduler.Coravel;
using JobSchedulerDemo.Scheduler.Quartz.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureMassTransitJobPublisher(builder.Configuration["RabbitMQHost"]);

builder.Services.ConfigureApplicationServices();

builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigurePushMessages(builder.Configuration);

builder.Services.ConfigureQuartzSchedulerServices(builder.Configuration);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
}
else
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.CreateScheduledJobsDatabase(app.Services);

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseEndpoints(endpoints =>
{
  endpoints.MapRazorPages();
});

app.UseCoravelPro();

app.Run();
