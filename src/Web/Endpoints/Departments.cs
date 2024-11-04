using CSharpie.Tasks.Application.Departments.Commands.CreateDepartment;
using CSharpie.Tasks.Application.Departments.Commands.DeleteDepartment;
using CSharpie.Tasks.Application.Departments.Commands.UpdateDepartment;
using CSharpie.Tasks.Application.Departments.Queries.GetDepartments;

namespace CSharpie.Tasks.Web.Endpoints;

public class Departments : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetDepartments)
            .MapPost(CreateDepartment)
            .MapPut(UpdateDepartment, "{id}")
            .MapDelete(DeleteDepartment, "{id}");
    }

    public Task<DepartmentsVM> GetDepartments(ISender sender)
    {
        return sender.Send(new GetDepartmentsQuery());
    }

    public Task<int> CreateDepartment(ISender sender, CreateDepartmentCommand command)
    {
        return sender.Send(command);
    } 

    public async Task<IResult> UpdateDepartment(ISender sender, int id, UpdateDepartmentCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteDepartment(ISender sender, int id)
    {
        await sender.Send(new DeleteDepartmentCommand(id));
        return Results.NoContent();
    }
}
