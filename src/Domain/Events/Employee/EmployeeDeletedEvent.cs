namespace CSharpie.Tasks.Domain.Events.Employee;

public class EmployeeDeletedEvent : BaseEvent
{
    public EmployeeDeletedEvent(Entities.Employee employee)
    {
        Employee = employee;
    }
    public Entities.Employee Employee { get; }
}
