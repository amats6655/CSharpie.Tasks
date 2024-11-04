using CSharpie.Tasks.Application.Common.Interfaces;

namespace CSharpie.Tasks.Application.Positions.Commands.UpdatePosition;

public record UpdatePositionCommand : IRequest
{
    public int Id { get; init; }
    public int DepartmentId { get; init; }
    public string? Title { get; init; }
    public decimal Salary { get; init; }
}

public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePositionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Positions
            .FindAsync(new object[] {request.Id}, cancellationToken);
        
        Guard.Against.NotFound(request.Id, entity);
        
        entity.Title = request.Title;
        entity.DepartmentId = request.DepartmentId;
        entity.Salary = request.Salary;
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
