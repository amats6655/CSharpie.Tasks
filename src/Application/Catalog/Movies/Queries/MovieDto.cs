using CSharpie.Tasks.Application.Catalog.Genres.Queries;
using CSharpie.Tasks.Application.Catalog.Participant.Queries;
using CSharpie.Tasks.Application.Catalog.Reviews.Queries;
using CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

namespace CSharpie.Tasks.Application.Catalog.Movies.Queries;

public class MovieDto
{
    public MovieDto()
    {
        Actors = Array.Empty<ParticipantDto>();
        Reviews = Array.Empty<ReviewDto>();
        Genres = Array.Empty<GenreDto>();
    }
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public string? TrailerUrl { get; init; }
    public decimal Rating { get; init; }
    public int Year { get; init; }
    public decimal Budget { get; init; }
    public string? Language { get; init; }
    public string? Country { get; init; }
    public bool IsWatched { get; init; }
    public bool IsLiked { get; init; }
    public int MyRating { get; init; }
    public ParticipantDto? Director { get; init; }
    public IReadOnlyCollection<GenreDto>? Genres { get; init; }
    public IReadOnlyCollection<ParticipantDto>? Actors { get; init; }
    public IReadOnlyCollection<ReviewDto>? Reviews { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Movie, MovieDto>();
        }
    }
}
