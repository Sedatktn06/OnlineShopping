using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Models.AddressModels;

public static class AddressModelMapping
{
    public static IEnumerable<Address> ToEntities(this IEnumerable<AddressModel> models)
    {
        return models.Select(x => x.ToEntity());
    }

    public static IEnumerable<AddressModel> ToModels(this IEnumerable<Address> entities) 
    {
        return entities.Select(x => x.ToModel());
    }

    public static AddressModel ToModel(this Address entity) 
    {
        return new AddressModel
        {
            AddressId = entity.AddressId,
            UserId = entity.UserId,
            District = entity.District,
            City = entity.City,
            Detail = entity.Detail,
        };
    }
    public static Address ToEntity(this AddressModel model)
    {
        return new Address
        {
            AddressId = model.AddressId,
            City = model.City,
            Detail = model.Detail,
            District = model.District,
            UserId = model.UserId,
        };
    }
}
