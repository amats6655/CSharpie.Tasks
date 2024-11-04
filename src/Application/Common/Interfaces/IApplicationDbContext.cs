using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<Employee> Employees { get; }
    
    DbSet<Department> Departments { get; }
    
    DbSet<Position> Positions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
