using CSharpie.Tasks.Application.Common.Models;
using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Departments.Queries.GetDepartments;

public class DepartmentsVM
{
    public IReadOnlyCollection<DepartmentDto> Departments { get; init; } = Array.Empty<DepartmentDto>();
}
