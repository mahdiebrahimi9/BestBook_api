using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseOrderItemCountCommandHandler : IBaseCommandHandler<DecreaseOrderItemCountCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DecreaseOrderItemCountCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(DecreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentUser == null)
                return OperationResult.NotFound();

            currentUser.DecreaseItemCount(request.ItemId, request.Count);
            await _orderRepository.Save();

            return OperationResult.Success();
        }
    }
}
