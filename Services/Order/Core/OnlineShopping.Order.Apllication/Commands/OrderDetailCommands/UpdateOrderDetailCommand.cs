using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderDetailModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Commands.OrderDetailCommands;

public class UpdateOrderDetailCommand:IRequest
{
    public OrderDetailModel OrderDetailModel { get; set; }

    public UpdateOrderDetailCommand(OrderDetailModel orderDetailModel)
    {
        OrderDetailModel = orderDetailModel;
    }
}

public class UpdateOrderDetailCommandHandler:IRequestHandler<UpdateOrderDetailCommand>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await _orderDetailRepository.UpdateAsync(request.OrderDetailModel.ToEntity());
    }
}
