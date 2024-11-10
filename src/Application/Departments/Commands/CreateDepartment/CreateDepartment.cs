using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Application.Common.Security;
using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Departments.Commands.CreateDepartment;
[Authorize]
public record CreateDepartmentCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Department();
        
        entity.Title = request.Title;
        
        _context.Departments.Add(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity.Id;
    }
}
