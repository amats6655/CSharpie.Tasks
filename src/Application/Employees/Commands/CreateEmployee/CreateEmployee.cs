using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Domain.Entities;
using CSharpie.Tasks.Domain.Events.Employee;

namespace CSharpie.Tasks.Application.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommand : IRequest<int>
{
    public int PositionId{ get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? SurName { get; init; }
    public DateOnly DateOfBirth { get; init; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            SurName = request.SurName,
            DateOfBirth = request.DateOfBirth,
            PositionId = request.PositionId,
            DateOfWork = DateOnly.Parse(DateTime.UtcNow.ToLongDateString())
        };
        
        entity.AddDomainEvent(new EmployeeCreatedEvent(entity));
        
        _context.Employees.Add(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity.Id;
    }
}
