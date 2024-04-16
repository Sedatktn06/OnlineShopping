using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderDetailModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Commands.OrderDetailCommands;

public class CreateOrderDetailCommand:IRequest
{
    public OrderDetailModel OrderDetailModel { get; set; }

    public CreateOrderDetailCommand(OrderDetailModel orderDetailModel)
    {
        OrderDetailModel = orderDetailModel;
    }
}

public class CreateOrderDetailCommandHandler:IRequestHandler<CreateOrderDetailCommand>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await _orderDetailRepository.CreateAsync(request.OrderDetailModel.ToEntity());
    }
}
