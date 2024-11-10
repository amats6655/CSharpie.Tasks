namespace CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

public class Movie : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? TrailerUrl { get; set; }
    public decimal? Rating { get; set; }
    public int? Year { get; set; }
    public decimal? Budget { get; set; }
    public string? Language { get; set; }
    public string? Country { get; set; }
    public bool? IsWatched { get; set; }
    public bool? IsLiked { get; set; }
    public int? MyRating { get; set; }
    
    public int DirectorId { get; set; }
    public Director? Director { get; set; }
    public IList<Actor>? Actors { get; set; }
    public IList<Review>? Reviews { get; set; }
    public IList<Genre>? Genres { get; set; }
}
