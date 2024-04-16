using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Models.OrderDetailModels;

public static class OrderDetailModelMapping
{
    public static IEnumerable<OrderDetail> ToEntities(this IEnumerable<OrderDetailModel> models)
    {
        return models.Select(o => o.ToEntity());
    }
    public static IEnumerable<OrderDetailModel> ToModels(this IEnumerable<OrderDetail> entities)
    {
        return entities.Select(o => o.ToModel());
    }
    public static OrderDetail ToEntity(this OrderDetailModel orderDetailModel)
    {
        return new OrderDetail
        {
            OrderId = orderDetailModel.OrderId,
            OrderDetailId = orderDetailModel.OrderDetailId,
            ProductAmount = orderDetailModel.ProductAmount,
            ProductId = orderDetailModel.ProductId,
            ProductName = orderDetailModel.ProductName,
            ProductPrice = orderDetailModel.ProductPrice,
            ProductTotalPrice = orderDetailModel.ProductTotalPrice,
        };
    }

    public static OrderDetailModel ToModel(this OrderDetail orderDetail)
    {
        return new OrderDetailModel
        {
            OrderId = orderDetail.OrderId,
            ProductTotalPrice = orderDetail.ProductTotalPrice,
            ProductPrice = orderDetail.ProductPrice,
            OrderDetailId = orderDetail.OrderDetailId,
            ProductAmount = orderDetail.ProductAmount,
            ProductId = orderDetail.ProductId,
            ProductName = orderDetail.ProductName,
        };
    }
}
