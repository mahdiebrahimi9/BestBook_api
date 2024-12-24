using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categorys.AddChild
{
    public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidator()
        {
            RuleFor(r => r.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
        }
    }
}
