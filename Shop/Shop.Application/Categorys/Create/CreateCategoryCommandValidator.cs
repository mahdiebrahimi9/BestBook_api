using Common.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categorys.Create
{
    partial class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(r => r.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
        }

    }
}
