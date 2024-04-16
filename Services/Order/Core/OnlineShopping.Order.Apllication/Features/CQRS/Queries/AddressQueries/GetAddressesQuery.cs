using OnlineShopping.Order.Apllication.Features.CQRS.Results.AddressResults;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Features.CQRS.Queries.AddressQueries;

public class GetAddressesQuery
{

}

public class GetAddressesQueryHandler
{
    private readonly IRepository<Address> _addressRepository;

    public GetAddressesQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<List<AddressModel>> HandleAsync(GetAddressesQuery query)
    {
        var addresses = await _addressRepository.GetAllAsync();
        return addresses.ToModels().ToList();
    }
}

