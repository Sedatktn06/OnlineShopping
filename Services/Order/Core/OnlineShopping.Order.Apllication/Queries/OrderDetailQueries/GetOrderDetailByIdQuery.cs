using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.OrderDetailModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Queries.OrderDetailQueries;

public class GetOrderDetailByIdQuery:IRequest<OrderDetailModel>
{
    public int Id { get; set; }

    public GetOrderDetailByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetOrderDetailByIdQueryHandler:IRequestHandler<GetOrderDetailByIdQuery,OrderDetailModel>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<OrderDetailModel> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(request.Id);
        return orderDetail.ToModel();
    }
}
