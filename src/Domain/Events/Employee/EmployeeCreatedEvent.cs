namespace CSharpie.Tasks.Domain.Events.Employee;

public class EmployeeCreatedEvent : BaseEvent
{
    public EmployeeCreatedEvent(Entities.Employees.Employee employee)
    {
        Employee = employee;
    }
    public Entities.Employees.Employee Employee { get; }
}
