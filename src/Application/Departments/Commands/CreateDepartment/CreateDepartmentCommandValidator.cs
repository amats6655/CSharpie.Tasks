using CSharpie.Tasks.Application.Common.Interfaces;

namespace CSharpie.Tasks.Application.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100)
            .MustAsync(BeUniqueTitle)
                .WithMessage("Department name must be unique")
                .WithErrorCode("Unique");
    }   

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Departments
            .AllAsync(x => x.Title != title, cancellationToken);
    }
}
