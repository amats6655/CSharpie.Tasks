namespace CSharpie.Tasks.Domain.Entities.Employees;

public class Position : BaseAuditableEntity
{
    public string? Title { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public IList<Employee>? Employees { get; set; } = new List<Employee>();
}
