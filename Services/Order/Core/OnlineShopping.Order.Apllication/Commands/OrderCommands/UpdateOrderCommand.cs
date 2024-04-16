using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderModels;

namespace OnlineShopping.Order.Apllication.Commands.OrderCommands;

public class UpdateOrderCommand:IRequest
{
    public OrderModel OrderModel { get; set; }

    public UpdateOrderCommand(OrderModel orderModel)
    {
        OrderModel = orderModel;
    }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IRepository<Domain.Entities.Order> _orderRepository;

    public UpdateOrderCommandHandler(IRepository<Domain.Entities.Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.UpdateAsync(request.OrderModel.ToEntity());
    }
}
