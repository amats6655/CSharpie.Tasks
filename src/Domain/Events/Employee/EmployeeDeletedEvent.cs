namespace CSharpie.Tasks.Domain.Events.Employee;

public class EmployeeDeletedEvent : BaseEvent
{
    public EmployeeDeletedEvent(Entities.Employees.Employee employee)
    {
        Employee = employee;
    }
    public Entities.Employees.Employee Employee { get; }
}
