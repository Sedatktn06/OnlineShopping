using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.Address;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Features.CQRS.Commands.AddressCommands;

public class CreateAddressCommand
{
    public CreateAddressCommand(AddressModel addressModel)
    {
        AddressModel = addressModel;
    }

    public AddressModel AddressModel { get; set; }
}

public class CreateAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public CreateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task HandleAsync(CreateAddressCommand command)
    {
        await _addressRepository.CreateAsync(command.AddressModel.ToEntity());
    }
}
