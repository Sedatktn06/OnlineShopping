using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;

namespace OnlineShopping.Order.Apllication.Commands.OrderCommands;

public class RemoveOrderCommand:IRequest
{
    public int OrderId { get; set; }

    public RemoveOrderCommand(int orderId)
    {
        OrderId = orderId;
    }
}

public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
{
    private readonly IRepository<Domain.Entities.Order> _orderRepository;

    public RemoveOrderCommandHandler(IRepository<Domain.Entities.Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if (order != null) 
        {
            await _orderRepository.DeleteAsync(order);
        }
    }
}
