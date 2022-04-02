namespace JobSchedulerDemo.Application.MessageContracts.Hub;
public record PushMessage(string Id, string Name, string Status, DateTime Timestamp);