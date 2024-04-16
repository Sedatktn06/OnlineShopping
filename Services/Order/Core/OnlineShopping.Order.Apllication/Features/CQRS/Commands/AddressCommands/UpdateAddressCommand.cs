using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Features.CQRS.Commands.AddressCommands;

public class UpdateAddressCommand
{
    public AddressModel AddressModel { get; set; }

    public UpdateAddressCommand(AddressModel addressModel)
    {
        AddressModel = addressModel;
    }
}

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task HandleAsync(UpdateAddressCommand command)
    {
        await _addressRepository.UpdateAsync(command.AddressModel.ToEntity());
    }
}
