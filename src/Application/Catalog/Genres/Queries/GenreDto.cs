using CSharpie.Tasks.Application.Catalog.Movies.Queries;
using CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

namespace CSharpie.Tasks.Application.Catalog.Genres.Queries;

public class GenreDto
{
    public GenreDto()
    {
        Movies = Array.Empty<MovieDto>();
    }
    public int Id { get; init; }
    public string? Title { get; init; }
    public IReadOnlyCollection<MovieDto> Movies { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Genre, GenreDto>();
        }
    }
}
