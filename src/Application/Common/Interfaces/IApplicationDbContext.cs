using CSharpie.Tasks.Domain.Entities;
using CSharpie.Tasks.Domain.Entities.Catalogs.Movies;

namespace CSharpie.Tasks.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Employee> Employees { get; }
    
    DbSet<Department> Departments { get; }
    
    DbSet<Position> Positions { get; }
    DbSet<Movie> Movies { get; }
    DbSet<Director> Directors { get; }
    DbSet<Actor> Actors { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Genre> Genres { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
