using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.ChangeCount
{
    public class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentUser == null)
                OperationResult.NotFound();

            var address = new OrderAddress(request.Name, request.PhoneNumber, request.Shire, request.City,
                request.Family, request.PostalAddress, request.PostalCode, request.NationalCode);
            currentUser.CheckOut(address);
            return OperationResult.Success();
        }
    }
}
