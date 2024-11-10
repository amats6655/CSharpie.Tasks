using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Application.Common.Security;

namespace CSharpie.Tasks.Application.Departments.Commands.DeleteDepartment;

[Authorize]
public record DeleteDepartmentCommand(int id) : IRequest;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments
            .Where(i => i.Id == request.id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.id, entity);
        
        _context.Departments.Remove(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
