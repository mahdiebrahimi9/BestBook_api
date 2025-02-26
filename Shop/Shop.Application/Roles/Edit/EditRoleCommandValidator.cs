using Common.Application.Validation;
using FluentValidation;
using Shop.Application.Roles.Edit;

namespace Shop.Application.Roles.Edit;

public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandValidator()
    {
        RuleFor(r => r.title)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));
    }
}