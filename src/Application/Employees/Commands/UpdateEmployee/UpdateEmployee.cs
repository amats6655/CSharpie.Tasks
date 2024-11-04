using CSharpie.Tasks.Application.Common.Interfaces;

namespace CSharpie.Tasks.Application.Employees.Commands.UpdateEmployee;

public record UpdateEmployeeCommand : IRequest
{
    public int Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? SurName { get; init; }
    public int PositionId { get; init; }
    public DateOnly DateOfBirth { get; init; }
}

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees
            .FindAsync(new object[] {request.Id}, cancellationToken);
        
        Guard.Against.NotFound(request.Id, entity);
        
        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.SurName = request.SurName;
        entity.PositionId = request.PositionId;
        entity.DateOfBirth = request.DateOfBirth;
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}

