namespace CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

public class Genre : BaseEntity
{
    public string? Title { get; set; }
    public IList<Movie>? Movies { get; set; }
}
