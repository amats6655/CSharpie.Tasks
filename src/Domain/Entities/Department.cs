namespace CSharpie.Tasks.Domain.Entities;

public class Department : BaseAuditableEntity
{
    public string? Title { get; set; }
    public IList<Position>? Positions { get; set; } = new List<Position>();
}
