# Job Scheduler Demo

A demo application for scheduling jobs. Jobs are requested from the ClientUI and sent to a JobService via RabbitMQ. 

The jobs are scheduled using Hangfire and progress are reported back to the ClientUI using a SignalRHub.

## Introduction

**Links**
- [GitHub](https://github.com/migaweb/JobSchedulerDemo)

## Technology used
- Blazor
- SignalR
- Hangfire
- MassTransit
- RabbitMQ

## Architecture
1. JobService: Receives jobs via RabbitMQ and schedules the job with Hangfire. Can use multiple instances (configured in docker compose files).
2. ClientUI: Blazor application for triggering jobs and view its progress.
3. HangfireDashboard: The Hangfire dashboard for viewing scheduled jobs.
4. SignalRHub: Used for sending push messages with job status back to ClientUI.

### How to start
1. Install [Docker](https://www.docker.com/).
2. Open the solution in Visual Studio (2022)
3. Make the docker-compose project as Set as Startup Project in Visual Studio then click the debug button (or F5).

### Database migrations
Using Powershell.

Verbose (--verbose) is optional.

```
Add migration
dotnet ef migrations add Initial --context JobsDbContext -s ..\..\Web\Server --verbose

Update database
dotnet ef database update --context JobsDbContext -s ..\..\Web\Server --verbose
```

## Third party dependencies
The following are third-party libraries used by the different apps and their respective license.
### .NET
- AutoMapper, [MIT](https://mit-license.org/)
- MassTransit, [Apache-2.0](https://licenses.nuget.org/Apache-2.0)
- Hangfire, [LGPL](https://raw.githubusercontent.com/HangfireIO/Hangfire/master/LICENSE.md)
- RabbitMQ, [Mozilla Public License v 2.0](https://www.rabbitmq.com/mpl.html)
