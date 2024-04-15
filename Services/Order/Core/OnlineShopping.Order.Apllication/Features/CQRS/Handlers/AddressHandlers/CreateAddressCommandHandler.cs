using OnlineShopping.Order.Apllication.Features.CQRS.Commands.AddressCommands;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public CreateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task HandleAsync(CreateAddressCommand createAddressCommand)
    {
        await _addressRepository.CreateAsync(new Address
        {
            City = createAddressCommand.City,
            Detail = createAddressCommand.Detail,
            District = createAddressCommand.District,
            UserId = createAddressCommand.UserId
        });
    }
}
