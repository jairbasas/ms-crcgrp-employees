using FluentValidation;

namespace Employees.Application.Commands.EmployeeCommand
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(p => p.code)
                  .NotEmpty().WithMessage("{PropertyName}, es campo obligatorio.");

            RuleFor(p => p.name)
                  .NotEmpty().WithMessage("{PropertyName}, es campo obligatorio.");

            RuleFor(p => p.situationId)
                  .NotEmpty().WithMessage("{PropertyName}, es campo obligatorio.");
        }
    }
}
