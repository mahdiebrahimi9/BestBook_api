using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create;

public class EditRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public EditRoleCommandValidator()
    {
        RuleFor(r => r.title)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));
    }
}