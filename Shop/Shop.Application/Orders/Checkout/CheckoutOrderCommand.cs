using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Checkout
{
    public class CheckoutOrderCommand : IBaseCommand
    {
    }
    public class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
    {
        public Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {

        }
    }
}
