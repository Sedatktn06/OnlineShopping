using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Order.Apllication.Commands.AddressCommands;
using OnlineShopping.Order.Apllication.Commands.OrderCommands;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Apllication.Models.OrderModels;
using OnlineShopping.Order.Apllication.Queries.AddressQueries;
using OnlineShopping.Order.Apllication.Queries.OrderQueries;

namespace OnlineShopping.Order.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAdresses()
    {
        var addresses = await _mediator.Send(new GetAddressesQuery());
        return Ok(addresses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var address = await _mediator.Send(new GetAddressByIdQuery(id));
        return Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress(AddressModel model)
    {
        await _mediator.Send(new CreateAddressCommand(model));
        return Ok("Adres eklenmiştir.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAddress(int id)
    {
        await _mediator.Send(new RemoveAddressCommand(id));
        return Ok("Adres silinmiştir");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress(AddressModel model)
    {
        await _mediator.Send(new UpdateAddressCommand(model));
        return Ok("Adres güncellenmiştir.");
    }
}
