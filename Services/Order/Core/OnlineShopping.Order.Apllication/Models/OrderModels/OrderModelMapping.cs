using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Models.OrderModels;

public static class OrderModelMapping
{
    public static IEnumerable<Domain.Entities.Order> ToEntities(this IEnumerable<OrderModel> models)
    {
        return models.Select(o => o.ToEntity());
    }

    public static IEnumerable<OrderModel> ToModels(this IEnumerable<Domain.Entities.Order> entities)
    {
        return entities.Select(o => o.ToModel());
    }

    public static Domain.Entities.Order ToEntity(this OrderModel model)
    {
        return new Domain.Entities.Order
        {
            OrderId = model.OrderId,
            OrderDate = model.OrderDate,
            TotalPrice = model.TotalPrice,
            UserId = model.UserId,
        };
    }

    public static OrderModel ToModel(this Domain.Entities.Order entity)
    {
        return new OrderModel
        {
            UserId = entity.UserId,
            OrderDate = entity.OrderDate,
            OrderId = entity.OrderId,
            TotalPrice = entity.TotalPrice
        };
    }
}
