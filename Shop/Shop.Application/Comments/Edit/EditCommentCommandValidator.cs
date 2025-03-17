using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
      public  EditCommentCommandValidator()
        {
            RuleFor(r => r.text)
                .MinimumLength(5)
                .WithMessage(ValidationMessages.minLength("متن", 5));
        }
    }
}
