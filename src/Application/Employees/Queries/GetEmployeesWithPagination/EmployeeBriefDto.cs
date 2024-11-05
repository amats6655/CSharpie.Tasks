using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Employees.Queries.GetEmployeesWithPagination;

public class EmployeeBriefDto
{
    public int Id { get; init; }
    public string? Department { get; init; }
    public int DepartmentId { get; init; }
    public int PositionId { get; init; }
    public string? Position { get; init; }
    public string? Name { get; init; }
    public DateOnly? DateOfBirth { get; init; }
    public DateOnly? DateOfWork { get; init; }
    public Decimal? Salary { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? SurName { get; init; }
    

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee, EmployeeBriefDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(
                        src => $"{src.LastName} {src.FirstName} {src.SurName}"))
                .ForMember(
                    dest => dest.Position,
                    opt => opt.MapFrom(
                        src => src.Position!.Title))
                .ForMember(
                    dest => dest.Department,
                    opt => opt.MapFrom(
                        src => src.Position!.Department!.Title))
                .ForMember(
                    dest => dest.Salary,
                    opt => opt.MapFrom(
                        src => src.Position!.Salary))
                .ForMember(
                    dest => dest.DepartmentId,
                    opt => opt.MapFrom(
                        src => src.Position!.DepartmentId));
        }
    }
}
