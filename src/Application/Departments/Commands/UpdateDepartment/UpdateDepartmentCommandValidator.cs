using CSharpie.Tasks.Application.Common.Interfaces;

namespace CSharpie.Tasks.Application.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDepartmentCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(100)
            .MustAsync(BeUniqueTitle)
                .WithMessage("Title must be unique")
                .WithErrorCode("Unique");
    }   

    public async Task<bool> BeUniqueTitle(UpdateDepartmentCommand model, string title,
        CancellationToken cancellationToken)
    {
        return await _context.Departments
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
