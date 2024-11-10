namespace CSharpie.Tasks.Domain.Entities.Employees;

public class Employee :  BaseAuditableEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? SurName { get; set; }
    public int PositionId { get; set; }
    public Position? Position { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public DateOnly DateOfWork { get; set; }
}
