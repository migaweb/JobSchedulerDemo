using JobSchedulerDemo.HangfireDashboard.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureHangfire();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseHangfireDashboard();

app.Run();