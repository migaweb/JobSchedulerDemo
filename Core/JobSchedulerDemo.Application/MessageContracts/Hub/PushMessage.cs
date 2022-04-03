using JobSchedulerDemo.Application.Dtos;

namespace JobSchedulerDemo.Application.MessageContracts.Hub;
public record PushMessage(int Id, string Name, 
  string Status, DateTime Created, string? JobId,
  DateTime? Scheduled, DateTime? Started, DateTime? Completed, string? Error);