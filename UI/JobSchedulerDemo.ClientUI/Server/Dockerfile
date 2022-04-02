#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UI/JobSchedulerDemo.ClientUI/Server/JobSchedulerDemo.ClientUI.Server.csproj", "UI/JobSchedulerDemo.ClientUI/Server/"]
COPY ["UI/JobSchedulerDemo.ClientUI/Client/JobSchedulerDemo.ClientUI.Client.csproj", "UI/JobSchedulerDemo.ClientUI/Client/"]
COPY ["Core/JobSchedulerDemo.Application/JobSchedulerDemo.Application.csproj", "Core/JobSchedulerDemo.Application/"]
COPY ["UI/JobSchedulerDemo.ClientUI/Shared/JobSchedulerDemo.ClientUI.Shared.csproj", "UI/JobSchedulerDemo.ClientUI/Shared/"]
COPY ["Infrastructure/JobSchedulerDemo.Infrastructure/JobSchedulerDemo.Infrastructure.csproj", "Infrastructure/JobSchedulerDemo.Infrastructure/"]
RUN dotnet restore "UI/JobSchedulerDemo.ClientUI/Server/JobSchedulerDemo.ClientUI.Server.csproj"
COPY . .
WORKDIR "/src/UI/JobSchedulerDemo.ClientUI/Server"
RUN dotnet build "JobSchedulerDemo.ClientUI.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JobSchedulerDemo.ClientUI.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobSchedulerDemo.ClientUI.Server.dll"]