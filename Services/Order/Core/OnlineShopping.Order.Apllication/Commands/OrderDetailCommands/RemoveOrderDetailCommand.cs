using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Commands.OrderDetailCommands;

public class RemoveOrderDetailCommand:IRequest
{
    public int Id { get; set; }

    public RemoveOrderDetailCommand(int id)
    {
        Id = id;
    }
}

public class RemoveOrderDetailCommandHandler:IRequestHandler<RemoveOrderDetailCommand>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(request.Id);
        await _orderDetailRepository.DeleteAsync(orderDetail);
    }
}
