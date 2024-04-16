using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderModels;

namespace OnlineShopping.Order.Apllication.Commands.OrderCommands;

public class CreateOrderCommand:IRequest
{
    public OrderModel OrderModel { get; set; }

    public CreateOrderCommand(OrderModel orderModel)
    {
        OrderModel = orderModel;
    }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IRepository<Domain.Entities.Order> _orderRepository;

    public CreateOrderCommandHandler(IRepository<Domain.Entities.Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.CreateAsync(request.OrderModel.ToEntity());
    }
}
