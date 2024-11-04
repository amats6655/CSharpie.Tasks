using CSharpie.Tasks.Application.Positions.Commands.CreatePosition;
using CSharpie.Tasks.Application.Positions.Commands.DeletePosition;
using CSharpie.Tasks.Application.Positions.Commands.UpdatePosition;
using CSharpie.Tasks.Application.Positions.Queries.GetPositions;

namespace CSharpie.Tasks.Web.Endpoints;

public class Positions : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetPositions)
            .MapPost(CreatePosition)
            .MapPut(UpdatePosition, "{id}")
            .MapDelete(DeletePosition, "{id}");
    }

    public Task<PositionsVM> GetPositions(ISender sender)
    {
        return sender.Send(new GetPositionsQuery());
    }

    public Task<int> CreatePosition(ISender sender, CreatePositionCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdatePosition(ISender sender, int id, UpdatePositionCommand command)
    {
        if(id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeletePosition(ISender sender, int id)
    {
        await sender.Send(new DeletePositionCommand(id));
        return Results.NoContent();
    }
}
