using CSharpie.Tasks.Application.Catalog.Movies.Queries;
using CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

namespace CSharpie.Tasks.Application.Catalog.Reviews.Queries;

public class ReviewDto
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Content { get; init; }
    public int Rating { get; init; }
    public MovieDto? Movie { get; init; }
    public string? Author { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Review, ReviewDto>();
        }
    }
}
