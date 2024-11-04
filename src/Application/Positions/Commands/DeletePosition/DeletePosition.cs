using CSharpie.Tasks.Application.Common.Interfaces;

namespace CSharpie.Tasks.Application.Positions.Commands.DeletePosition;

public record DeletePositionCommand(int id) : IRequest;

public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePositionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Positions
            .Where(i => i.Id == request.id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.id, entity);
        
        _context.Positions.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
