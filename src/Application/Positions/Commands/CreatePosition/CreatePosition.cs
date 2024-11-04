using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Positions.Commands.CreatePosition;

public record CreatePositionCommand : IRequest<int>
{
    public string? Title { get; set; }
    public int DepartmentId {get; init;}
    public decimal Salary {get; init;}
}

public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePositionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Position();
        
        entity.Title = request.Title;
        entity.DepartmentId = request.DepartmentId;
        entity.Salary = request.Salary;
        
        _context.Positions.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity.Id;
    }
}
