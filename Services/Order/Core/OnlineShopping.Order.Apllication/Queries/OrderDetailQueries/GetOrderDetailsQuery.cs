using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderDetailModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Queries.OrderDetailQueries;

public class GetOrderDetailsQuery:IRequest<List<OrderDetailModel>>
{
}
public class GetOrderDetailsQueryHandler:IRequestHandler<GetOrderDetailsQuery,List<OrderDetailModel>>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public GetOrderDetailsQueryHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<List<OrderDetailModel>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var orderDetails = await _orderDetailRepository.GetAllAsync();
        return orderDetails.ToModels().ToList();
    }

}
