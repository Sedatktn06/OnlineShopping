using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Commands.AddressCommands;

public class CreateAddressCommand:IRequest
{
    public CreateAddressCommand(AddressModel addressModel)
    {
        AddressModel = addressModel;
    }

    public AddressModel AddressModel { get; set; }
}

public class CreateAddressCommandHandler:IRequestHandler<CreateAddressCommand>
{
    private readonly IRepository<Address> _addressRepository;

    public CreateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        await _addressRepository.CreateAsync(request.AddressModel.ToEntity());
    }
}
