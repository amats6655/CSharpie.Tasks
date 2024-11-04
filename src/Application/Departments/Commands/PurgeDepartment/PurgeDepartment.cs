using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Application.Common.Security;
using CSharpie.Tasks.Domain.Constants;

namespace CSharpie.Tasks.Application.Departments.Commands.PurgeDepartment;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]

public record PurgeDepartmentCommand : IRequest;

public class PurgeDepartmentCommandHandler : IRequestHandler<PurgeDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeDepartmentCommand request, CancellationToken cancellationToken)
    {
        _context.Departments.RemoveRange(_context.Departments);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
}
