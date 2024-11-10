using CSharpie.Tasks.Application.Catalog.Movies.Queries;
using CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

namespace CSharpie.Tasks.Application.Catalog.Participant.Queries;

public class ParticipantDto
{
    public ParticipantDto()
    {
        Movies = Array.Empty<MovieDto>();
    }
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Biography { get; init; }
    public DateOnly BirthDate { get; init; }
    public bool IsAlive { get; init; }
    public IReadOnlyList<MovieDto> Movies { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Director, ParticipantDto>();
            CreateMap<Actor, ParticipantDto>();
        }
    }
}
