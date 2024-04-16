using MediatR;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Commands.AddressCommands;

public class UpdateAddressCommand:IRequest
{
    public AddressModel AddressModel { get; set; }

    public UpdateAddressCommand(AddressModel addressModel)
    {
        AddressModel = addressModel;
    }
}

public class UpdateAddressCommandHandler:IRequestHandler<UpdateAddressCommand>
{
    private readonly IRepository<Address> _addressRepository;

    public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        await _addressRepository.UpdateAsync(request.AddressModel.ToEntity());
    }
}
