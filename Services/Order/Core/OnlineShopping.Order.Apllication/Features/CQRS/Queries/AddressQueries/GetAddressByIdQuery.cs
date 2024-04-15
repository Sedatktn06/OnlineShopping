namespace OnlineShopping.Order.Apllication.Features.CQRS.Queries.AddressQueries;

public class GetAddressByIdQuery
{
    public int Id { get; set; }

    public GetAddressByIdQuery(int id)
    {
        Id = id;
    }
}
