using CSharpie.Tasks.Application.Common.Models;
using CSharpie.Tasks.Application.Employees.Commands.CreateEmployee;
using CSharpie.Tasks.Application.Employees.Commands.DeleteEmployee;
using CSharpie.Tasks.Application.Employees.Commands.UpdateEmployee;
using CSharpie.Tasks.Application.Employees.Queries.GetEmployee;
using CSharpie.Tasks.Application.Employees.Queries.GetEmployeesWithPagination;

namespace CSharpie.Tasks.Web.Endpoints;

public class Employees : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetEmployeesWithPagination)
            .MapGet(GetEmployeeById, "{id}")
            .MapPost(CreateEmployee)
            .MapPut(UpdateEmployee, "{id}")
            .MapDelete(DeleteEmployee, "{id}");
    }
    
    public Task<PaginatedList<EmployeeBriefDto>> GetEmployeesWithPagination(ISender sender, [AsParameters] GetEmployeesWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<EmployeeBriefDto> GetEmployeeById(ISender sender, [AsParameters] GetEmployeeByIdQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateEmployee(ISender sender, CreateEmployeeCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateEmployee(ISender sender, int id, UpdateEmployeeCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteEmployee(ISender sender, int id)
    {
        await sender.Send(new DeleteEmployeeCommand(id));
        return Results.NoContent();
    }
}
