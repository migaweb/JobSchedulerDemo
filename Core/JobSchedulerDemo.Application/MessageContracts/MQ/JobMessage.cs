namespace JobSchedulerDemo.Application.MessageContracts.MQ;

public record JobMessage(string Id, string Name, bool Cancel);
