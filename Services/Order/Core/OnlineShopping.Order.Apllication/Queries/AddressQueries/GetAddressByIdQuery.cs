using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Queries.AddressQueries;

public class GetAddressByIdQuery:IRequest<AddressModel>
{
    public int Id { get; set; }

    public GetAddressByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetAddressByIdQueryHandler:IRequestHandler<GetAddressByIdQuery,AddressModel>
{
    private readonly IRepository<Address> _addressRepository;

    public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<AddressModel> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.GetByIdAsync(request.Id);
        return address.ToModel();
    }
}
