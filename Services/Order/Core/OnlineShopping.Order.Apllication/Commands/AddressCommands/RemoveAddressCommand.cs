using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Commands.AddressCommands;

public class RemoveAddressCommand:IRequest
{
    public int Id { get; set; }

    public RemoveAddressCommand(int id)
    {
        Id = id;
    }
}

public class RemoveAddressCommandHandler:IRequestHandler<RemoveAddressCommand>
{
    private readonly IRepository<Address> _addressRepository;

    public RemoveAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.GetByIdAsync(request.Id);
        if (address != null)
        {
            await _addressRepository.DeleteAsync(address);
        }
    }

}
