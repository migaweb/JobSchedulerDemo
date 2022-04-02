#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UI/JobSchedulerDemo.JobService/JobSchedulerDemo.JobService.csproj", "UI/JobSchedulerDemo.JobService/"]
COPY ["Infrastructure/JobSchedulerDemo.Infrastructure/JobSchedulerDemo.Infrastructure.csproj", "Infrastructure/JobSchedulerDemo.Infrastructure/"]
COPY ["Core/JobSchedulerDemo.Application/JobSchedulerDemo.Application.csproj", "Core/JobSchedulerDemo.Application/"]
RUN dotnet restore "UI/JobSchedulerDemo.JobService/JobSchedulerDemo.JobService.csproj"
COPY . .
WORKDIR "/src/UI/JobSchedulerDemo.JobService"
RUN dotnet build "JobSchedulerDemo.JobService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JobSchedulerDemo.JobService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobSchedulerDemo.JobService.dll"]
