namespace CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

public class BaseParticipant : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Biography { get; set; }
    public DateOnly BirthDate { get; set; }
    public bool IsAlive { get; set; } = true;
    public IList<Movie>? Movies { get; set; }
}
