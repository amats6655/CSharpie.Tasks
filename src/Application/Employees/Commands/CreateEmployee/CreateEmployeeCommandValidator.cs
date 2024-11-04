namespace CSharpie.Tasks.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(e => e.FirstName)
            .MaximumLength(50)
            .MinimumLength(2)
            .NotEmpty();
        RuleFor(e => e.LastName)
            .MaximumLength(50)
            .MinimumLength(2)
            .NotEmpty();
        RuleFor(e => e.SurName)
            .MaximumLength(50)
            .MinimumLength(2)
            .NotEmpty();
    }
}
