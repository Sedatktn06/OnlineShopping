using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderModels;

namespace OnlineShopping.Order.Apllication.Queries.OrderQueries;

public class GetOrderByIdQuery:IRequest<OrderModel>
{
    public int OrderId { get; set; }

    public GetOrderByIdQuery(int orderId)
    {
        OrderId = orderId;
    }
}

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderModel>
{
    private readonly IRepository<Domain.Entities.Order> _orderRepository;

    public GetOrderByIdQueryHandler(IRepository<Domain.Entities.Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        return order.ToModel();
    }
}
