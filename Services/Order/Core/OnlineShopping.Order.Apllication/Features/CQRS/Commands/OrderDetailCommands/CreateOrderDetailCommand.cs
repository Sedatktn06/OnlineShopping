using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderDetailModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Features.CQRS.Commands.OrderDetailCommands;

public class CreateOrderDetailCommand
{
    public OrderDetailModel OrderDetailModel { get; set; }

    public CreateOrderDetailCommand(OrderDetailModel orderDetailModel)
    {
        OrderDetailModel = orderDetailModel;
    }
}

public class CreateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task HandleAsync(CreateOrderDetailCommand command)
    {
        await _orderDetailRepository.CreateAsync(command.OrderDetailModel.ToEntity());
    }
}
