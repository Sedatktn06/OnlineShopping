using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController : ControllerBase
{
    private readonly ICargoOperationService _cargoOperationService;
    private readonly IMapper _mapper;

    public CargoOperationsController(ICargoOperationService cargoOperationService, IMapper mapper)
    {
        _cargoOperationService = cargoOperationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cargoOperations = await _cargoOperationService.TGetAllAsync();
        return Ok(cargoOperations);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCargoOperationDto createCargoOperationDto)
    {
        await _cargoOperationService.TInsertAsync(_mapper.Map<CargoOperation>(createCargoOperationDto));
        return Ok("Kargo operasyonu oluşturuldu.");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _cargoOperationService.TDeleteAsync(id);
        return Ok("Kargo operasyonu kaldırıldı.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var cargoOperation = await _cargoOperationService.TGetByIdAsync(c => c.Id == id);
        return Ok(cargoOperation);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCargoOperationDto updateCargoOperationDto)
    {
        await _cargoOperationService.TUpdateAsync(_mapper.Map<CargoOperation>(updateCargoOperationDto));
        return Ok("Kargo operasyonu güncellendi.");
    }
}
