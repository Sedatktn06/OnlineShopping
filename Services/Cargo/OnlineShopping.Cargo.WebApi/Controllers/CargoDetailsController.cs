using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController : ControllerBase
{
    private readonly ICargoDetailService _cargoDetailService;
    private readonly IMapper _mapper;

    public CargoDetailsController(ICargoDetailService cargoDetailService, IMapper mapper)
    {
        _cargoDetailService = cargoDetailService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cargoDetails = await _cargoDetailService.TGetAllAsync();
        return Ok(cargoDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCargoDetailDto createCargoDetailDto)
    {
        await _cargoDetailService.TInsertAsync(_mapper.Map<CargoDetail>(createCargoDetailDto));
        return Ok("Kargo detayı oluşturuldu.");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _cargoDetailService.TDeleteAsync(id);
        return Ok("Kargo detayı kaldırıldı.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var cargoDetail = await _cargoDetailService.TGetByIdAsync(c => c.Id == id);
        return Ok(cargoDetail);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCargoDetailDto updateCargoDetailDto)
    {
        await _cargoDetailService.TUpdateAsync(_mapper.Map<CargoDetail>(updateCargoDetailDto));
        return Ok("Kargo detayı güncellendi.");
    }
}
