using CSharpie.Tasks.Domain.Events.Employee;
using Microsoft.Extensions.Logging;

namespace CSharpie.Tasks.Application.Employees.EventHandlers;

public class EmployeeCreateEventHandler : INotificationHandler<EmployeeCreatedEvent>
{
    private readonly ILogger<EmployeeCreateEventHandler> _logger;

    public EmployeeCreateEventHandler(ILogger<EmployeeCreateEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CSharpie.Tasks Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}
