namespace CSharpie.Tasks.Domain.Entities.Employees;

public class Department : BaseAuditableEntity
{
    public string? Title { get; set; }
    public IList<Position>? Positions { get; set; } = new List<Position>();
}
