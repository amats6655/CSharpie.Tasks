namespace CSharpie.Tasks.Application.Positions.Queries.GetPositions;

public class PositionsVM
{
    public IReadOnlyCollection<PositionDto> Positions { get; init; } = Array.Empty<PositionDto>();

}
