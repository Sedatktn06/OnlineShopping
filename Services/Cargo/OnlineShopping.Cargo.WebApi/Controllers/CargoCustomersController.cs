using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController : ControllerBase
{
    private readonly ICargoCustomerService _cargoCustomerService;
    private readonly IMapper _mapper;

    public CargoCustomersController(ICargoCustomerService cargoCustomerService, IMapper mapper)
    {
        _cargoCustomerService = cargoCustomerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cargoCustomers = await _cargoCustomerService.TGetAllAsync();
        return Ok(cargoCustomers);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCargoCustomerDto createCargoCustomerDto)
    {
        await _cargoCustomerService.TInsertAsync(_mapper.Map<CargoCustomer>(createCargoCustomerDto));
        return Ok("Kargo müşterisi oluşturuldu.");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _cargoCustomerService.TDeleteAsync(id);
        return Ok("Kargo müşterisi kaldırıldı.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var cargoCustomer = await _cargoCustomerService.TGetByIdAsync(c => c.Id == id);
        return Ok(cargoCustomer);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        await _cargoCustomerService.TUpdateAsync(_mapper.Map<CargoCustomer>(updateCargoCustomerDto));
        return Ok("Kargo müşterisi güncellendi.");
    }
}
