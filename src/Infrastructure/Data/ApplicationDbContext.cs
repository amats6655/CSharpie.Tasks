using System.Reflection;
using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Domain.Entities.Catalogs.Movies;
using CSharpie.Tasks.Domain.Entities.Employees;
using CSharpie.Tasks.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSharpie.Tasks.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Department> Departments => Set<Department>();
    
    public DbSet<Employee> Employees => Set<Employee>();
    
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
