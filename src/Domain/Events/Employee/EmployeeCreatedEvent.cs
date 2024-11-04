namespace CSharpie.Tasks.Domain.Events.Employee;

public class EmployeeCreatedEvent : BaseEvent
{
    public EmployeeCreatedEvent(Entities.Employee employee)
    {
        Employee = employee;
    }
    public Entities.Employee Employee { get; }
}
