using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Positions.Queries.GetDepartments;

public class EmployeeDto
{
    public int Id { get; init; }
    public int PositionId { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? SurName { get; init; }
    public DateOnly? DateOfBirth { get; init; }
    public DateOnly? DateOfWork { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}