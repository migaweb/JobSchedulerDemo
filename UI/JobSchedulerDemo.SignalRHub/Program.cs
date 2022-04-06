
using JobSchedulerDemo.Application.Constants;
using JobSchedulerDemo.SignalRHub.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

var MyAllowSpecificOrigins = "_specificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                      builder.WithOrigins("https://localhost:7285",
                                            "http://localhost:5285"
                                            , "http://localhost:8001")
                      .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
});

builder.Services.AddResponseCompression(opts =>
{
  opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
      new[] { "application/octet-stream" });
});

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.MapHub<PushMessageHub>("/pushmessagehub");

app.MapHealthChecks(HealthCheckConstants.Url);

app.Run();
