using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Queries.OrderQueries;

public class GetOrdersQuery:IRequest<List<OrderModel>>
{
}

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderModel>>
{
    private readonly IRepository<Domain.Entities.Order> _orderRepository;

    public GetOrdersQueryHandler(IRepository<Domain.Entities.Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.ToModels().ToList();
    }
}
