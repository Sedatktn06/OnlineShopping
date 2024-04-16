using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Features.CQRS.Commands.AddressCommands;

public class RemoveAddressCommand
{
    public int Id { get; set; }

    public RemoveAddressCommand(int id)
    {
        Id = id;
    }
}

public class RemoveAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public RemoveAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task HandleAsync(RemoveAddressCommand command)
    {
        var address = await _addressRepository.GetByIdAsync(command.Id);
        if (address != null)
        {
            await _addressRepository.DeleteAsync(address);
        }
    }
}
