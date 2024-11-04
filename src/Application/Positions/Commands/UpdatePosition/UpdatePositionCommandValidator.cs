using CSharpie.Tasks.Application.Common.Interfaces;

namespace CSharpie.Tasks.Application.Positions.Commands.UpdatePosition;

public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePositionCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(100);
    }
}
