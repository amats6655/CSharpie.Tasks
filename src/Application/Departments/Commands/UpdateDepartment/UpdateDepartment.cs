using CSharpie.Tasks.Application.Common.Interfaces;

namespace CSharpie.Tasks.Application.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand : IRequest
{
    public int Id { get; init; }
    public string? Title { get; init; }
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments
            .FindAsync(new object[] {request.Id}, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);
        
        entity.Title = request.Title;
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
