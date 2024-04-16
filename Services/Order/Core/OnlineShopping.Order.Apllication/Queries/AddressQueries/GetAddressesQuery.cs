using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Queries.AddressQueries;

public class GetAddressesQuery:IRequest<List<AddressModel>>
{
}
public class GetAddressesQueryHandler:IRequestHandler<GetAddressesQuery,List<AddressModel>>
{
    private readonly IRepository<Address> _addressRepository;

    public GetAddressesQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<List<AddressModel>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
    {
        var addresses = await _addressRepository.GetAllAsync();
        return addresses.ToModels().ToList();
    }
}

