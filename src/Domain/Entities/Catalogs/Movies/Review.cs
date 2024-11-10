namespace CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

public class Review : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public int Rating { get; set; }
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
}
