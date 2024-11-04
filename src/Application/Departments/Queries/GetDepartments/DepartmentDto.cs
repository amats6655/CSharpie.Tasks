using CSharpie.Tasks.Application.Positions.Queries.GetPositions;
using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Departments.Queries.GetDepartments;

public class DepartmentDto
{
    public DepartmentDto()
    {
        Positions = Array.Empty<PositionDto>();
    }
    public int Id { get; init; }
    public string? Title { get; init; }
    
    public IReadOnlyCollection<PositionDto> Positions { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}
