using CSharpie.Tasks.Application.Positions.Queries.GetDepartments;


namespace CSharpie.Tasks.Application.Positions.Queries.GetPositions;

public class PositionDto
{
    public PositionDto()
    {
        Employees = Array.Empty<EmployeeDto>();
    }
    
    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    
    public IReadOnlyCollection<EmployeeDto> Employees { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Position, PositionDto>();
        }
    }
}
